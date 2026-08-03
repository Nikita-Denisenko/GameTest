using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class WeaponStatData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public WeaponStatType Type { get; }

        public WeaponStatData(
            int id,
            string name,
            string description,
            WeaponStatType type)
        {
            if (id <= 0)
                throw new InvalidWeaponStateException("Weapon stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidWeaponStateException("Weapon stat name cannot be empty.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
        }
    }
}
