using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

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
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(WeaponStatType), type))
                throw new DomainException("Invalid WeaponStatType");

            Name = name;
            Description = description;
            Type = type;
        }
    }
}