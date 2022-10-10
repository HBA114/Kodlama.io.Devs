using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaimCommand;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, GetByIdUserOperationClaimDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, GetListUserOperationClaimsModel>().ReverseMap();
    }
}