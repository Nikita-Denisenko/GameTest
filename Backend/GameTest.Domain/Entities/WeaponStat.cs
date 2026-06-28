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