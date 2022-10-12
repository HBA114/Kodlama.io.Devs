using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules;
public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim? userOperationClaim)
    {
        if (userOperationClaim == null) throw new BusinessException("Requested UserOperationClaim not exists!");
    }
}