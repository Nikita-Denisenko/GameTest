using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class CatStat
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public CatStatType Type { get; private set; }

        private CatStat() { }

        public CatStat(
            string name, 
            string description, 
            CatStatType type) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be null or empty.");

            Name = name;
            Description = description;
            Type = type;
        }
    }
}
