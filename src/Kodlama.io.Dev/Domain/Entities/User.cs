using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string GithubUrl { get; set; } // ekleyebilmeli silebilmeli veya güncelleyebilmelidir.
        // Github Url : Property olarak verilebilir. 
    }
}
