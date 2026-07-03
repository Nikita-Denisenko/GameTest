using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class WeaponStat
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public WeaponStatType Type { get; private set; }

        private WeaponStat() { }

        public WeaponStat(string name, string description, WeaponStatType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            if (!Enum.IsDefined(typeof(WeaponStatType), type))
                throw new ArgumentException("Invalid WeaponStatType", nameof(type));

            Name = name;
            Description = description;
            Type = type;
        }
    }
}