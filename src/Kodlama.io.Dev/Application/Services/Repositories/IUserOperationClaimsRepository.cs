using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IUserOperationClaimsRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {

    }
}
