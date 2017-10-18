using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using bc.cores.common;
using bc.cores.models;
using bc.cores.repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace bc.cores.jwt
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private UserManager<ApplicationUser> _userManager;
        private UserRepository _userRepository;
        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager, UserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;

            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            if (context.Request.Method.Equals("POST") && context.Request.HasFormContentType)
            {
                return GenerateToken(context);
            }

            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Bad Request");
        }
        
        private async Task GenerateToken(HttpContext context)
        {
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            var rememberMe = context.Request.Form.ContainsKey("remember_me")
                && string.Equals(
                    context.Request.Form["remember_me"].ToString().ToLower(),
                    bool.TrueString.ToLower(), StringComparison.CurrentCultureIgnoreCase);
            var user = await _userManager.FindByEmailAsync(username); //_userRepository.GetByEmail(username);
            if (user == null)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(
                    new
                    {
                        Message = $@"User ""{username}"" not found",
                        Code = ApiMessage.UserNotFound.ToString()
                    },
                    new JsonSerializerSettings { Formatting = Formatting.Indented }));
                return;
            }

            var result = _userManager.CheckPasswordAsync(user, password);
            if (result.Result == false)
            {
                context.Response.StatusCode = 400;
                await _userManager.AccessFailedAsync(user);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        Message = $@"Password is not correct",
                        Code = ApiMessage.PasswordIncorrect.ToString()
                    },
                    new JsonSerializerSettings { Formatting = Formatting.Indented }));
                return;
            }
            var timespan = DateTimeOffset.UtcNow;
            var now = timespan.Date;
            var totalExpirationSecond = rememberMe 
                ? TimeSpan.FromDays(100).TotalSeconds // 3 months is enough
                : _options.Expiration.TotalSeconds;
            var expiredAt = timespan.Date.AddSeconds(totalExpirationSecond);

            await _userManager.ResetAccessFailedCountAsync(user);
            var userClaims = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64)
            };

            claims.AddRange(userClaims.Select(x => new Claim(ClaimTypes.Role, x)));
            
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: expiredAt,
                signingCredentials: _options.SigningCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedJwt = tokenHandler.WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                issued_at = timespan.ToUnixTimeSeconds(),
                expires_in = totalExpirationSecond,
                expired_at = timespan.AddSeconds(totalExpirationSecond).ToUnixTimeSeconds(),
                user_info = new
                {
                    user.Id,
                    user.UserName,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.EmailConfirmed,
                    user.PhoneNumber,
                    user.PhoneNumberConfirmed
                }
            };
           
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}
