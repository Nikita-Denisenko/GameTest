using Assets.Scripts.Enums;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelWeaponPropertyInfo
    {
        public string PropertyName { get; private set; }
        public WeaponStatType StatType {  get; private set; }
        public float? Bonus { get; private set; }

        public NextLevelWeaponPropertyInfo(
            string propertyName, 
            WeaponStatType statType, 
            float? bonus)
        {
            PropertyName = propertyName;
            StatType = statType;
            Bonus = bonus;
        }
    }
}
