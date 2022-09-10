using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubLinks.Queries
{
    public class GetByIdGithubLinkQuery : IRequest<GithubLinkGetbyIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubLinkQueryHandler : IRequestHandler<GetByIdGithubLinkQuery, GithubLinkGetbyIdDto>
        {
            private readonly IGithubLinkRepository _githubLinkRepository;
            private readonly IMapper _mapper;
            private readonly GithubLinkBusinessRules _githubLinkBusinessRules;

            public GetByIdGithubLinkQueryHandler(IGithubLinkRepository githubLinkRepository, IMapper mapper, GithubLinkBusinessRules githubLinkBusinessRules)
            {
                _githubLinkRepository = githubLinkRepository;
                _mapper = mapper;
                _githubLinkBusinessRules = githubLinkBusinessRules;
            }

            public async Task<GithubLinkGetbyIdDto> Handle(GetByIdGithubLinkQuery request, CancellationToken cancellationToken)
            {
                await _githubLinkBusinessRules.GithubLinkShouldExistWhenRequested(request.Id);

                GithubLink githubLink = await _githubLinkRepository.GetAsync(p => p.Id == request.Id);

                GithubLinkGetbyIdDto result = _mapper.Map<GithubLinkGetbyIdDto>(githubLink);
                return result;
            }
        }
    }
}
