using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using bc.cores.repositories.Models;
using bc.cores.repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
//            string clientId = context.Request.Form["client_id"];
//            string clientSecret = context.Request.Form["client_secret"];
//            ApplicationUser user = _db..Where(x => x.UserName == username).FirstOrDefault();
            var user = _userRepository.GetByEmail(username);
            var result = _userManager.CheckPasswordAsync(user, password);
            if (result.Result == false)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password");
                return;
            }
            var now = DateTime.UtcNow;
            
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
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}
