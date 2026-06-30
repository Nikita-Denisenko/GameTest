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
        public string Name => UnitProperty.Name;
        public UnitStatType StatType => UnitProperty.StatType;

        private PlayerUnitProperty() { }

        public PlayerUnitProperty(int playerUnitId, UnitProperty unitProperty, int level = 1)
        {
            PlayerUnitId = playerUnitId;
            UnitPropertyId = unitProperty.Id;
            UnitProperty = unitProperty;
            Level = level;
            Value = unitProperty.GetValueAtLevel(level);
        }

        public void UpLevel()
        {
            if (Level >= UnitProperty.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this unit property.");
            Level++;
            RecalculateValue();
        }

        private void RecalculateValue() => Value = UnitProperty.GetValueAtLevel(Level);
    }
}
