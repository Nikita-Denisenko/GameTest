using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class PlayerWeaponProperty
    {
        public int Id { get; private set; }
        public int PlayerWeaponId { get; private set; }
        public PlayerWeapon PlayerWeapon { get; private set; } = null!;
        public int WeaponPropertyId { get; private set; }
        public WeaponProperty WeaponProperty { get; private set; } = null!;
        public int Level { get; private set; }
        public double Value { get; private set; }
        public string Name => WeaponProperty.Name;
        public WeaponStatType StatType => WeaponProperty.StatType;

        private PlayerWeaponProperty() { }

        public PlayerWeaponProperty(int playerWeaponId, WeaponProperty weaponProperty, int level = 1)
        {
            PlayerWeaponId = playerWeaponId;
            WeaponPropertyId = weaponProperty.Id;
            WeaponProperty = weaponProperty;
            Level = level;
            Value = weaponProperty.GetValueAtLevel(level);
        }

        public void UpLevel()
        {
            if (Level >= WeaponProperty.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this weapon property.");
            Level++;
            RecalculateValue();
        }

        private void RecalculateValue() => Value = WeaponProperty.GetValueAtLevel(Level);
    }
}