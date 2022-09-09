using FluentValidation;

namespace Application.Features.GithubLinks.Commands.CreateGithubLink
{
    public class CreateGithubLinkCommandValidator : AbstractValidator<CreateGithubLinkCommand>
    {
        public CreateGithubLinkCommandValidator()
        {
            RuleFor(p => p.UserId).GreaterThan(0).NotNull();
            RuleFor(p => p.Url).NotEmpty();
        }
    }
}
