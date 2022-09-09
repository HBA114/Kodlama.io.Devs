using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class GithubLink : Entity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public virtual User? User { get; set; }

        public GithubLink()
        {

        }

        public GithubLink(int id, int userId, string url)
        {
            Id = id;
            UserId = userId;
            Url = url;
        }
    }
}
