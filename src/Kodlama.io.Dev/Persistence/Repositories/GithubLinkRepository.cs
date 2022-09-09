using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GithubLinkRepository : EfRepositoryBase<GithubLink, BaseDbContext>, IGithubLinkRepository
    {
        public GithubLinkRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
