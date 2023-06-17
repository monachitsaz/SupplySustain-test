using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using SupplySustainEvaluation.Chitsaz.Common;
using SupplySustainEvaluation.Chitsaz.Services;

namespace SupplySustainEvaluation.Chitsaz
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            #region DI
            services.AddScoped(typeof(ISqlUtility), typeof(SqlUtility));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy("SupplySustainEvaluation.Chitsaz",
                    builder =>
                    {
                        //here you can give special domain or ip
                        builder.WithOrigins("*");
                        builder.WithHeaders("*");
                        builder.WithMethods("*");

                    });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("ClientApp",
                    builder =>
                    {
                        //here you can give special domain or ip
                        builder.WithOrigins("*");
                        builder.WithHeaders("*");
                        builder.WithMethods("*");

                    });
            });
            #endregion

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors("SupplySustainEvaluation.Chitsaz");
            app.UseCors("ClientApp");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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
