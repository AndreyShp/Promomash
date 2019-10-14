using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promomash.Common.DAL.Repositories.Contracts;
using Promomash.Regions.WebApi.DAL.Context;
using Promomash.Regions.WebApi.DAL.Repositories;
using Promomash.Regions.WebApi.DAL.Repositories.Contracts;
using Promomash.Regions.WebApi.Managers;
using Promomash.Regions.WebApi.Managers.Contracts;
using Promomash.Regions.WebApi.Mapper;

namespace Promomash.Regions.WebApi.Helpers {
    /// <summary>
    /// Подготовительные действия для запуска приложения
    /// </summary>
    public static class ApplicationStartupHelper {
        /// <summary>
        /// Внедрение зависимостей приложения
        /// </summary>
        /// <param name="services">описание сервисов</param>
        /// <param name="configuration">настройки</param>
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration) {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<RegionsDbContext>(options => {
                                                        string connectionString = configuration["AppSettings:ConnectionString"];
                                                        options.UseSqlServer(connectionString);
                                                    });
            services.AddScoped<IRegionsRepository, RegionsRepository>();
            services.AddScoped<IRegionsManager, RegionsManager>();
        }

        /// <summary>
        /// Накатывает миграцию на базу данных
        /// </summary>
        /// <param name="app">пайплайн приложения</param>
        public static void DatabaseMigrate(IApplicationBuilder app) {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<RegionsDbContext>();
                context.Database.Migrate();
            }
        }
    }
}