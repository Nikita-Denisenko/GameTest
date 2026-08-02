using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

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
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidValueObjectException(
                    "Passive ability name cannot be empty.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Passive ability bonus cannot be negative.");

            Name = name;
            Type = type;
            Bonus = bonus;
        }
    }
}
