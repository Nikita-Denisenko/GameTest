using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelUnitPropertyInfo
    {
        public string PropertyName { get; }
        public UnitStatType StatType { get; }
        public float? Bonus { get; }

        public NextLevelUnitPropertyInfo(
            string propertyName,
            UnitStatType statType,
            float? bonus)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new InvalidValueObjectException(
                    "Property name cannot be empty.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Property bonus cannot be negative.");

            PropertyName = propertyName;
            StatType = statType;
            Bonus = bonus;
        }
    }
}
