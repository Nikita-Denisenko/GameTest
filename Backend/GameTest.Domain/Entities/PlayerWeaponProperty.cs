using GameTest.Domain.Exceptions;

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
        public double? NextLevelValue { get; private set; }

        private PlayerWeaponProperty() { }

        public PlayerWeaponProperty(WeaponProperty weaponProperty, int level = 1)
        {
            if (weaponProperty == null)
                throw new DomainException("Weapon property cannot be null");

            if (level < 1)
                throw new DomainException("Level must be a positive number");

            WeaponPropertyId = weaponProperty.Id;
            WeaponProperty = weaponProperty;
            Level = level;
            Value = weaponProperty.GetValueAtLevel(level);
            NextLevelPrice = weaponProperty.GetNextLevelPrice(level);
            NextLevelValue = weaponProperty.GetNextLevelValue(level);
        }

        public void UpLevel()
        {
            if (Level >= WeaponProperty.MaxLevel)
                throw new DomainException("You have reached the maximum level for this weapon property.");
            Level++;
            RecalculateValue();
            RecalculateNextLevelPrice();
            RecalculateNextLevelValue();
        }

        private void RecalculateValue() => Value = WeaponProperty.GetValueAtLevel(Level);
        private void RecalculateNextLevelPrice() => NextLevelPrice = WeaponProperty.GetNextLevelPrice(Level);
        private void RecalculateNextLevelValue() => NextLevelValue = WeaponProperty.GetNextLevelValue(Level);

        public bool CanUpgrade => NextLevelPrice.HasValue;
    }
}