using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Commands.CreateGithubLink;
using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubLinks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // List Query
            CreateMap<GithubLink, GithubLinkListDto>()
                .ForMember(t => t.UserEmail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();

            CreateMap<IPaginate<GithubLink>, GithubLinkListModel>().ReverseMap();

            // Create Command
            CreateMap<GithubLink, CreatedGithubLinkDto>()
                .ReverseMap();

            CreateMap<GithubLink, CreateGithubLinkCommand>()
                .ReverseMap();

            // Update Command
            CreateMap<GithubLink, UpdateGithubLinkDto>()
                .ReverseMap();

            // GetById and Delete
            CreateMap<GithubLink, GithubLinkGetbyIdDto>()
                .ForMember(t => t.UserEmail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();
        }
    }
}
