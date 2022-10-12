using FluentValidation;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}