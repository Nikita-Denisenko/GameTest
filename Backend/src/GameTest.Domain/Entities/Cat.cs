using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class Cat
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        private readonly List<CatProperty> _properties = [];
        public IReadOnlyCollection<CatProperty> Properties => _properties;

        public CatType Type { get; private set; }
        public int Price { get; private set; }

        private Cat() { }

        public Cat(
            string name,
            string description,
            IEnumerable<CatProperty> properties,
            CatType type,
            int price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be null or empty.");

            if (properties == null || !properties.Any())
                throw new DomainException("Properties cannot ne empty.");

            if (price < 0)
                throw new DomainException("Price cannot be negative");

            Name = name;
            Description = description;
            _properties.AddRange(properties);
            Type = type;
            Price = price;
        }
    }
}
