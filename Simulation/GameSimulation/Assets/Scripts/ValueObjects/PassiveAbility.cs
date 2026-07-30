using Assets.Scripts.Enums;

namespace Assets.Scripts.ValueObjects
{
    public class PassiveAbility
    {
        public string Name { get; }
        public PassiveAbilityType Type { get; }
        public float Bonus { get; }

        public PassiveAbility(
            string name, 
            PassiveAbilityType type, 
            float bonus)
        {
            Name = name;
            Type = type;
            Bonus = bonus;
        }
    }
}
