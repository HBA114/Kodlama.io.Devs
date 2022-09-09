using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimsRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimsRepository
    {
        public UserOperationClaimsRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
