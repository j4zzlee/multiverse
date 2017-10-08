using System;
using System.Text;
using bc.cores.repositories;
using bc.cores.repositories.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace bc.cores.jwt
{
    public static class TokenProviderMiddlewareExtensions
    {
        public static void UseDefaultIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
                {
                    o.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>()
                .AddDefaultTokenProviders();
        }

        public static IApplicationBuilder UseJwtTokenProviderMiddleware(this IApplicationBuilder builder, IConfiguration configuration)
        {
            var secretKey = configuration.GetSection("JwtAuthentication:SecretKey").Value;
            var issuer = configuration.GetSection("JwtAuthentication:Issuer").Value;
            var audience = configuration.GetSection("JwtAuthentication:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            return builder.UseMiddleware<TokenProviderMiddleware>(Options.Create(new TokenProviderOptions
            {
                Audience = audience,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            }));
        }

        public static IServiceCollection UseJwtTokenProviderMiddleware(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secretKey = configuration.GetSection("JwtAuthentication:SecretKey").Value;
            var issuer = configuration.GetSection("JwtAuthentication:Issuer").Value;
            var audience = configuration.GetSection("JwtAuthentication:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //The signing key must match !
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        //Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        //validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = audience,

                        //validate the token expiry
                        ValidateLifetime = true,

                        // If you  want to allow a certain amout of clock drift
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}