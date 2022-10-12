using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(p => p.UserId).NotNull().GreaterThan(0);
        RuleFor(p => p.OperationClaimId).NotNull().GreaterThan(0);
    }
}