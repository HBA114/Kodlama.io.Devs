using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UserOperationClaims.Models;
public class GetListUserOperationClaimsModel : BasePageableModel
{
    public ICollection<GetByIdUserOperationClaimDto> Items { get; set; }
}