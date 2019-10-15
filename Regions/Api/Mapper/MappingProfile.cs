using AutoMapper;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.Mapper {
    internal class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<RegionDto, Region>();
        }
    }
}