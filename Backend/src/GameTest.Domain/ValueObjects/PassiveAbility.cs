using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record PassiveAbility
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public double Bonus { get; private set; }
        public PassiveAbilityType Type { get; private set; }

        public PassiveAbility(
            string name,
            double bonus,
            string description,
            PassiveAbilityType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            if (bonus < 0)
                throw new DomainException("Bonus cannot be negative");

            Name = name;
            Bonus = bonus;
            Description = description;
            Type = type;
        }
    }
}
