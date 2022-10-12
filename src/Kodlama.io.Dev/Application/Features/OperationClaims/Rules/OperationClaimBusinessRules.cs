using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == name);
        if (operationClaim != null) throw new BusinessException("Operation Claim Name Already Exists!");
    }

    public void OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
    {
        if (operationClaim == null) throw new BusinessException("Requested Operation Claim Not Found!");
    }
}