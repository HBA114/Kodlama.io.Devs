using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubLinks.Commands.DeleteGithubLink;
public class DeleteGithubLinkCommand : IRequest<GithubLinkGetbyIdDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } = { "User" };

    public class DeleteGithubLinkCommandHandler : IRequestHandler<DeleteGithubLinkCommand, GithubLinkGetbyIdDto>
    {
        private readonly IGithubLinkRepository _githubLinkRepository;
        private readonly IMapper _mapper;
        private readonly GithubLinkBusinessRules _githubLinkBusinessRules;

        public DeleteGithubLinkCommandHandler(IGithubLinkRepository githubLinkRepository, IMapper mapper, GithubLinkBusinessRules githubLinkBusinessRules)
        {
            _githubLinkRepository = githubLinkRepository;
            _mapper = mapper;
            _githubLinkBusinessRules = githubLinkBusinessRules;
        }

        public async Task<GithubLinkGetbyIdDto> Handle(DeleteGithubLinkCommand request, CancellationToken cancellationToken)
        {
            await _githubLinkBusinessRules.GithubLinkShouldExistWhenRequested(request.Id);

            IPaginate<GithubLink> githubLinks = await _githubLinkRepository.GetListAsync(
                p => p.Id == request.Id,
                include: p => p.Include(c => c.User)
                );
            GithubLink githubLink = githubLinks.Items.FirstOrDefault();

            await _githubLinkRepository.DeleteAsync(githubLink);

            GithubLinkGetbyIdDto result = _mapper.Map<GithubLinkGetbyIdDto>(githubLink);
            return result;
        }
    }
}