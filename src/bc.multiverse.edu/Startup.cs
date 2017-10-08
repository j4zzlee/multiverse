using System;
using bc.cores.jwt;
using bc.cores.modular;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bc.multiverse.edu.Services;
using Microsoft.Extensions.Logging;

namespace bc.multiverse.edu
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

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton(Configuration);

            services.UseDefaultIdentity(Configuration);
            var mvcBuilder = services.AddMvc();
            services.UseModulars(mvcBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseModulars(serviceProvider);
            
        }
    }
}
