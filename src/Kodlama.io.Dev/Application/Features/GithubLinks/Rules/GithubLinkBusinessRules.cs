using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.GithubLinks.Rules
{
    public class GithubLinkBusinessRules
    {
        private readonly IGithubLinkRepository _githubLinkRepository;

        public GithubLinkBusinessRules(IGithubLinkRepository userLinkRepository)
        {
            _githubLinkRepository = userLinkRepository;
        }

        public async Task GithubLinkShouldExistWhenRequested(int id)
        {
            GithubLink? githubLink = await _githubLinkRepository.GetAsync(p => p.Id == id);
            if (githubLink == null) throw new BusinessException("GithubLink Not Found!");
        }
        public async Task CanNotAddSecondLinkToUser(int userId)
        {
            GithubLink? githubLink =await _githubLinkRepository.GetAsync(p => p.UserId == userId);
            if (githubLink != null) throw new BusinessException("Can Not Add GithubLink! User already have a GithubLink.");
        }
    }
}
