using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class Weapon
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public WeaponType Type { get; private set; }

        private readonly List<WeaponProperty> _properties = [];
        public IReadOnlyCollection<WeaponProperty> Properties => _properties;

        private readonly List<TemporaryUpgradeLevel> _temporaryUpgradeLevels = [];
        public IReadOnlyCollection<TemporaryUpgradeLevel> TemporaryUpgradeLevels => _temporaryUpgradeLevels;

        private Weapon() { }

        public Weapon(
            string name, 
            string description,
            WeaponType type, 
            IEnumerable<WeaponProperty> properties,
            IEnumerable<TemporaryUpgradeLevel> temporaryUpgradeLevels)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(WeaponType), type))
                throw new DomainException("Invalid WeaponType");

            if (properties == null || !properties.Any())
                throw new DomainException("Properties cannot be empty");

            if (temporaryUpgradeLevels == null || !temporaryUpgradeLevels.Any())
                throw new DomainException("Temporary upgrade levels cannot be empty");

            Name = name;
            Description = description;
            Type = type;
            _properties.AddRange(properties);
            _temporaryUpgradeLevels.AddRange(temporaryUpgradeLevels);
        }
    }
}
