using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IGithubLinkRepository : IAsyncRepository<GithubLink>, IRepository<GithubLink>
    {
    }
}
