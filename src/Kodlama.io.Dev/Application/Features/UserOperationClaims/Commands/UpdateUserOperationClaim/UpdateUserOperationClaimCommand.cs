using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<GetByIdUserOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles { get; } = { "User" };

    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, GetByIdUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<GetByIdUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id);
            _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(userOperationClaim);
            userOperationClaim.UserId = request.UserId;
            userOperationClaim.OperationClaimId = request.OperationClaimId;
            await _userOperationClaimRepository.UpdateAsync(userOperationClaim);

            GetByIdUserOperationClaimDto mappedGetByIdUserOperationClaimDto = _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);
            return mappedGetByIdUserOperationClaimDto;
        }
    }
}