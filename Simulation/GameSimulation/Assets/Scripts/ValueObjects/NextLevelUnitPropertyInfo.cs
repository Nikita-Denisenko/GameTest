using Assets.Scripts.Enums;


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
            PropertyName = propertyName;
            StatType = statType;
            Bonus = bonus;
        }
    }
}
