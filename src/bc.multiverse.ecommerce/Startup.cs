using System;
using System.IO;
using System.Linq;
using System.Reflection;
using bc.cores.modulars;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bc.multiverse.ecommerce.Data;
using bc.multiverse.ecommerce.Models;
using bc.multiverse.ecommerce.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

namespace bc.multiverse.ecommerce
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();


            var mvcBuilder = services.AddMvc();
            services.AddSingleton(o => mvcBuilder);
            services.AddSingleton(o => services);

            var mainAssembly = GetType().GetTypeInfo().Assembly;
            var fileProvider = new CompositeFileProvider(new EmbeddedFileProvider(mainAssembly));
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(fileProvider);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceCollection services, IServiceProvider serviceProvider, IMvcBuilder mvcBuilder)
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

            AddModules(app, env, services, serviceProvider, mvcBuilder);
        }

        private void AddModules(IApplicationBuilder app, IHostingEnvironment env, IServiceCollection services, IServiceProvider serviceProvider, IMvcBuilder mvcBuilder)
        {

            var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var allModules = Directory.GetFiles(assemblyPath, "bc.modules.*.dll")
                .Select(f => Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(f))))
                .SelectMany(a => a.DefinedTypes)
                .Where(t => typeof(IModule).GetTypeInfo().IsAssignableFrom(t.AsType())
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(t => (IModule)Activator.CreateInstance(t.AsType()));

            foreach (var m in allModules)
            {
                m
                    .SetServiceConllection(services)
                    .SetServiceProvider(serviceProvider)
                    .AddMvc(mvcBuilder)
                    .SetApplication(app)
                    .Load();
            }
        }
    }
}
