using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(p => p.Name).NotNull();
    }
}