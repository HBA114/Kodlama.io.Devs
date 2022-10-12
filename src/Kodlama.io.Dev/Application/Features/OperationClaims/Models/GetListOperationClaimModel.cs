using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.OperationClaims.Models;

public class GetListOperationClaimModel : BasePageableModel
{
    public ICollection<GetByIdOperationClaimDto> Items { get; set; }
}