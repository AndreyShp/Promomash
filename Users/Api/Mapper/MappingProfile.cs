using AutoMapper;
using Promomash.Users.Contracts.Data;
using Promomash.Users.WebApi.DAL.Dto;

namespace Promomash.Users.WebApi.Mapper {
    internal class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore()).ReverseMap();
        }
    }
}