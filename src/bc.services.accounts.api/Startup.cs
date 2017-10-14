using System;
using bc.cores.jwt;
using bc.cores.modular;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bc.services.accounts.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(l => l
                .AddConsole()
                .AddDebug()
                .AddConfiguration(Configuration.GetSection("Logging")));
            
            services.AddSingleton(Configuration);
            
            // Identity
            services.UseDefaultIdentity(Configuration);
            
            // Jwt
            services.UseJwtTokenProviderMiddleware(Configuration);

            var mvcBuilder = services.AddMvc();
            services.UseModulars(mvcBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Authentication
            app.UseAuthentication();
            
            // JWT
            app.UseJwtTokenProviderMiddleware(configuration);

            app.UseMvc();

            app.UseModulars(serviceProvider);
        }
    }
}
