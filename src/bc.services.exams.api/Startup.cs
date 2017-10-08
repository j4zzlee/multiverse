using System;
using bc.cores.modular;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bc.services.exams.api
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
            var mvcBuilder = services.AddMvc();
            services.UseModulars(mvcBuilder);

            var audience = Configuration.GetSection("JwtAuthentication:Audience").Value;
            var authority = Configuration.GetSection("JwtAuthentication:Authority").Value;
            // jwt forward to main service bc.multiverse.edu
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.Audience = audience;
                    o.Authority = authority;
                    o.SaveToken = true;
                    o.RequireHttpsMetadata = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
            app.UseModulars(provider);
        }
    }
}
