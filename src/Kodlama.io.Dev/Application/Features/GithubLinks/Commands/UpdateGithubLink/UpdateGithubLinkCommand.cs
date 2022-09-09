using Application.Features.AppUsers.Rules;
using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubLinks.Commands.UpdateGithubLink
{
    public class UpdateGithubLinkCommand : IRequest<UpdateGithubLinkDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public class UpdateGithubLinkCommandHandler : IRequestHandler<UpdateGithubLinkCommand, UpdateGithubLinkDto>
        {
            private readonly IGithubLinkRepository _githubLinkRepository;
            private readonly IMapper _mapper;
            private readonly GithubLinkBusinessRules _githubLinkBusinessRules;

            public UpdateGithubLinkCommandHandler(IGithubLinkRepository githubLinkRepository, IMapper mapper, GithubLinkBusinessRules githubLinkBusinessRules, UserBusinessRules userBusinessRules)
            {
                _githubLinkRepository = githubLinkRepository;
                _mapper = mapper;
                _githubLinkBusinessRules = githubLinkBusinessRules;
            }
            public async Task<UpdateGithubLinkDto> Handle(UpdateGithubLinkCommand request, CancellationToken cancellationToken)
            {
                await _githubLinkBusinessRules.GithubLinkShouldExistWhenRequested(request.Id);

                GithubLink githubLink = await _githubLinkRepository.GetAsync(p => p.Id == request.Id);
                githubLink.Url = request.Url;

                await _githubLinkRepository.UpdateAsync(githubLink);

                UpdateGithubLinkDto result = _mapper.Map<UpdateGithubLinkDto>(githubLink);
                return result;
            }
        }
    }
}
