using BrainWareCore.Configs;
using BrainWareCore.Data;
using BrainWareCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrainWareCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration information</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration information
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Collection of services to configure</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Setup DI
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();

            // Setup the EF context
            services.AddDbContext<BrainWareContext>
                (options => options.UseSqlServer(
                    (Configuration.GetConnectionString("BrainWare") ?? "")
                    .Replace($"%{Constants.ASPNetCoreContentRootKey}%", Configuration.GetValue<string>(Constants.ASPNetCoreContentRootKey))
                    ));

            // Setup Swagger
            SwaggerConfig.ConfigureServices(services);
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">App middleware configuration</param>
        /// <param name="env">Environmental information</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            SwaggerConfig.Configure(app, env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
               
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
