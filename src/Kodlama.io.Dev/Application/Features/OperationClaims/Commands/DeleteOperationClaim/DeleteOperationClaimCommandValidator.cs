using FluentValidation;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim;
public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().GreaterThan(0);
    }
}