using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.GameData.StaticData
{
    public class CatData
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public IReadOnlyCollection<CatPropertyData> Properties { get; } = null!;
        public CatType Type { get; }
        public int Price { get; }

        public CatData(
            int id,
            string name,
            string description,
            IReadOnlyCollection<CatPropertyData> properties,
            CatType type,
            int price)
        {
            if (id <= 0)
                throw new InvalidCatStateException("Cat Id must be positive.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCatStateException("Cat name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidCatStateException("Cat description cannot be empty.");

            if (properties == null || !properties.Any())
                throw new InvalidCatStateException("Cat properties cannot be empty.");

            if (price < 0)
                throw new InvalidCatStateException("Cat price cannot be negative");

            Id = id; 
            Name = name; 
            Description = description;
            Properties = properties;
            Type = type;
            Price = price;
        }
    }
}
