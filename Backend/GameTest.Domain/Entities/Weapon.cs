using GameTest.Domain.Enums;

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

        private Weapon() { }

        public Weapon(string name, string description, WeaponType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty");
            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}