using Microsoft.EntityFrameworkCore;
using Promomash.Regions.Contracts.Enums;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.DAL.Context {
    /// <summary>
    /// Отвечает за заполнение базы изначальными данными
    /// </summary>
    internal class InitialRegionsCreator {
        public static void Create(ModelBuilder modelBuilder) {
            //TODO: вынести эти данные б json-файла
            var regions = new[] {
                                    new RegionDto {Id = 1, Name = "Китай", Type = RegionType.Country},
                                    new RegionDto {Id = 2, Name = "Россия", Type = RegionType.Country},
                                    new RegionDto
                                    {Id = 3, Name = "Соединенные штаты Америки", Type = RegionType.Country},
                                    new RegionDto {Id = 4, Name = "Аньхой", ParentId = 1, Type = RegionType.Province},
                                    new RegionDto {Id = 5, Name = "Фуцзянь", ParentId = 1, Type = RegionType.Province},
                                    new RegionDto
                                    {Id = 6, Name = "Московская область", ParentId = 2, Type = RegionType.Province},
                                    new RegionDto
                                    {Id = 7, Name = "Тульская область", ParentId = 2, Type = RegionType.Province},
                                    new RegionDto
                                    {Id = 8, Name = "Республика Калмыкия", ParentId = 2, Type = RegionType.Province},
                                    new RegionDto
                                    {Id = 9, Name = "Рязанская область", ParentId = 2, Type = RegionType.Province},
                                    new RegionDto {Id = 10, Name = "Аляска", ParentId = 3, Type = RegionType.Province},
                                    new RegionDto
                                    {Id = 11, Name = "Калифорния", ParentId = 3, Type = RegionType.Province},
                                    new RegionDto {Id = 12, Name = "Флорида", ParentId = 3, Type = RegionType.Province}
                                };
            modelBuilder.Entity<RegionDto>().HasData(regions);
        }
    }
}