using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommand : IRequest<GetByIdOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Roles { get; } = { "Admin" };

    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, GetByIdOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<GetByIdOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
            _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);
            operationClaim.Name = request.Name;
            await _operationClaimRepository.UpdateAsync(operationClaim);
            GetByIdOperationClaimDto getByIdOperationClaimDto = _mapper.Map<GetByIdOperationClaimDto>(operationClaim);

            return getByIdOperationClaimDto;
        }
    }
}