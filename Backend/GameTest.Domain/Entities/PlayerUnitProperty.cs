using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class PlayerUnitProperty
    {
        public int Id { get; private set; }
        public int PlayerUnitId { get; private set; }
        public PlayerUnit PlayerUnit { get; private set; } = null!;
        public int UnitPropertyId { get; private set; }
        public UnitProperty UnitProperty { get; private set; } = null!;
        public int Level { get; private set; }
        public double Value { get; private set; }
        public int? NextLevelPrice { get; private set; }
        public double? NextLevelValue { get; private set; }
        public string Name => UnitProperty.Name;
        public UnitStatType StatType => UnitProperty.StatType;

        private PlayerUnitProperty() { }

        public PlayerUnitProperty(UnitProperty unitProperty, int level = 1)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be a positive number");

            UnitPropertyId = unitProperty.Id;
            UnitProperty = unitProperty;
            Level = level;
            Value = unitProperty.GetValueAtLevel(level);
            NextLevelPrice = unitProperty.GetNextLevelPrice(level);
            NextLevelValue = unitProperty.GetNextLevelValue(level);
        }

        public void UpLevel()
        {
            if (Level >= UnitProperty.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this unit property.");
            Level++;
            RecalculateValue();
            RecalculateNextLevelPrice();
            RecalculateNextLevelValue();
        }

        private void RecalculateValue() => Value = UnitProperty.GetValueAtLevel(Level);
        private void RecalculateNextLevelPrice() => NextLevelPrice = UnitProperty.GetNextLevelPrice(Level);
        private void RecalculateNextLevelValue() => NextLevelValue = UnitProperty.GetNextLevelValue(Level);
    }
}
