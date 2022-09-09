using Application.Features.GithubLinks.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.GithubLinks.Models
{
    public class GithubLinkListModel : BasePageableModel
    {
        public ICollection<GithubLinkListDto> Items { get; set; }
    }
}
