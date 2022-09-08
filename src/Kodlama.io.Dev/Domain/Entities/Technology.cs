using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }


        public Technology()
        {

        }

        public Technology(int id, int programmingLanguageId, string name, string description)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Description = description;
        }
    }
}
