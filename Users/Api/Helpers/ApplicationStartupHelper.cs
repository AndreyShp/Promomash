using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promomash.Users.WebApi.DAL.Context;
using Promomash.Users.WebApi.DAL.Repositories;
using Promomash.Users.WebApi.DAL.Repositories.Contracts;
using Promomash.Users.WebApi.Managers;
using Promomash.Users.WebApi.Managers.Contracts;
using Promomash.Users.WebApi.Mapper;

namespace Promomash.Users.WebApi.Helpers {
    /// <summary>
    /// Подготовительные действия для запуска приложения
    /// </summary>
    internal static class ApplicationStartupHelper {
        /// <summary>
        /// Внедрение зависимостей приложения
        /// </summary>
        /// <param name="services">описание сервисов</param>
        /// <param name="configuration">настройки</param>
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration) {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<UsersDbContext>(options => {
                                                        string connectionString = configuration["AppSettings:ConnectionString"];
                                                        options.UseSqlServer(connectionString);
                                                    });
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddSingleton<IPasswordEncryptor>(options => {
                                                          string salt = configuration["AppSettings:Encryptor:Salt"];
                                                          int countIterations =
                                                              configuration.GetValue<int>("AppSettings:Encryptor:CountIterations");
                                                          var result = new PasswordEncryptor(salt, countIterations);
                                                          return result;
                                                      });
            services.AddScoped<IUsersManager, UsersManager>();
        }

        /// <summary>
        /// Накатывает миграцию на базу данных
        /// </summary>
        /// <param name="app">пайплайн приложения</param>
        public static void DatabaseMigrate(IApplicationBuilder app) {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<UsersDbContext>();
                context.Database.Migrate();
            }
        }
    }
}