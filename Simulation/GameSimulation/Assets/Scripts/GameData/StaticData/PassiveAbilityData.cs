using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class PassiveAbilityData
    {
        public string Name { get; }
        public string Description { get; }
        public float Bonus { get; }
        public PassiveAbilityType Type { get; }

        public PassiveAbilityData(
            string name,
            string description,
            float bonus,
            PassiveAbilityType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidValueObjectException("Passive ability name cannot be empty.");

            Name = name;
            Description = description ?? string.Empty;
            Bonus = bonus;
            Type = type;
        }
    }
}
