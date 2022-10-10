using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries;
public class GetUserOperationClaimListByUserIdQuery : IRequest<GetListUserOperationClaimsModel>
{
    public int UserId { get; set; }

    public class GetUserOperationClaimListByUserIdQueryHandler : IRequestHandler<GetUserOperationClaimListByUserIdQuery, GetListUserOperationClaimsModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetUserOperationClaimListByUserIdQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListUserOperationClaimsModel> Handle(GetUserOperationClaimListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(o => o.UserId == request.UserId);
            GetListUserOperationClaimsModel mappedResult = _mapper.Map<GetListUserOperationClaimsModel>(userOperationClaims);
            return mappedResult;
        }
    }
}