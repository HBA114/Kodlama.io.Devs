using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim;
public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles { get; } = { "Admin" };

    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);
            CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);

            return createdOperationClaimDto;
        }
    }
}