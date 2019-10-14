using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promomash.Regions.WebApi.Helpers;

namespace Promomash.Regions.WebApi {
    public class Startup {
        private const string WebApiAllowSpecificOrigins = "webApiAllowSpecificOrigins";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(options => {
                                 options.AddPolicy(WebApiAllowSpecificOrigins,
                                     builder => {
                                         var originsSection = Configuration.GetSection("AppSettings:CorsOrigins");
                                         var origins = originsSection.Get<string[]>();
                                         builder.WithOrigins(origins)
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                         ;
                                     });
                             });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //зависимости приложения
            ApplicationStartupHelper.InjectDependencies(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(WebApiAllowSpecificOrigins);

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //накатываем миграцию если нужно
            ApplicationStartupHelper.DatabaseMigrate(app);
        }
    }
}