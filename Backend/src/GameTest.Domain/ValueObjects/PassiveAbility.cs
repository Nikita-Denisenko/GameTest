using GameTest.Domain.Enums;

namespace GameTest.Domain.ValueObjects
{
    public record PassiveAbility
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public double Bonus { get; private set; }
        public PassiveAbilityType Type { get; private set; }

        public PassiveAbility
        (
            string name,
            double bonus,
            string description,
            PassiveAbilityType type
        )
        {
            Name = name;
            Bonus = bonus;
            Description = description;
            Type = type;
        }
    }
}
