using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim;
public class GetListOperationClaimQuery : IRequest<GetListOperationClaimModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, GetListOperationClaimModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListOperationClaimModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            
            GetListOperationClaimModel mappedListOperationClaimModel = _mapper.Map<GetListOperationClaimModel>(operationClaims);
            return mappedListOperationClaimModel;
        }
    }
}