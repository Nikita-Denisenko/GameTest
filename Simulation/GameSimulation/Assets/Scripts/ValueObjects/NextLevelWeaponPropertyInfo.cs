using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelWeaponPropertyInfo
    {
        public string PropertyName { get; }
        public WeaponStatType StatType { get; }
        public float? Bonus { get; }

        public NextLevelWeaponPropertyInfo(
            string propertyName,
            WeaponStatType statType,
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
