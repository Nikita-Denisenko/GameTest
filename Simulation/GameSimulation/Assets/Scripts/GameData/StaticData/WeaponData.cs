using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class WeaponData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public WeaponType Type { get; }
        public IReadOnlyCollection<WeaponPropertyData> Properties { get; }

        public WeaponData(
            int id,
            string name,
            string description,
            WeaponType type,
            IReadOnlyCollection<WeaponPropertyData> properties)
        {
            if (id <= 0)
                throw new InvalidWeaponStateException("Weapon id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidWeaponStateException("Weapon name cannot be empty.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
            Properties = properties ?? throw new InvalidWeaponStateException("Properties cannot be null.");
        }
    }
}
