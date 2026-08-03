using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.GameData.Runs
{
    public class RunWeaponData
    {
        public int PlayerWeaponId { get; }
        public int WeaponId { get; }
        public IReadOnlyCollection<RunWeaponPropertyData> Properties { get; }


        public RunWeaponData(
            int playerWeaponId,
            int weaponId,
            IReadOnlyCollection<RunWeaponPropertyData> properties)
        {
            if (playerWeaponId <= 0)
                throw new InvalidValueObjectException(
                    "Player weapon id must be greater than zero.");

            if (weaponId <= 0)
                throw new InvalidValueObjectException(
                    "Weapon id must be greater than zero.");

            PlayerWeaponId = playerWeaponId;
            WeaponId = weaponId;

            Properties = properties
                ?? throw new InvalidValueObjectException(
                    "Weapon properties cannot be null.");
        }
    }
}
