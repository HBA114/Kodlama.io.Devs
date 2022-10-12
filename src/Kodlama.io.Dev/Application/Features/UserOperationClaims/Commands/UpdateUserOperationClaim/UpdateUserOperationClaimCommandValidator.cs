using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommandValidator : AbstractValidator<UpdateUserOperationClaimCommand>
{
    public UpdateUserOperationClaimCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().GreaterThan(0);
        RuleFor(p => p.UserId).NotNull().GreaterThan(0);
        RuleFor(p => p.OperationClaimId).NotNull().GreaterThan(0);
    }
}