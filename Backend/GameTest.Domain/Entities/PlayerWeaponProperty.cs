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
        public int? NextLevelPrice { get; private set; }
        public string Name => WeaponProperty.Name;
        public WeaponStatType StatType => WeaponProperty.StatType;

        private PlayerWeaponProperty() { }

        public PlayerWeaponProperty(WeaponProperty weaponProperty, int level = 1)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be a positive number");

            WeaponPropertyId = weaponProperty.Id;
            WeaponProperty = weaponProperty;
            Level = level;
            Value = weaponProperty.GetValueAtLevel(level);
            NextLevelPrice = weaponProperty.GetNextLevelPrice(level);
        }

        public void UpLevel()
        {
            if (Level >= WeaponProperty.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this weapon property.");
            Level++;
            RecalculateValue();
            RecalculateNextLevelPrice();
        }

        private void RecalculateValue() => Value = WeaponProperty.GetValueAtLevel(Level);
        private void RecalculateNextLevelPrice() => NextLevelPrice = WeaponProperty.GetNextLevelPrice(Level);
    }
}