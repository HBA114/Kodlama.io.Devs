using Application.Features.AppUsers.Commands.RegisterAppUser;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.AppUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<AccessToken, RegisterUserCommand>().ReverseMap();
        }
    }
}
