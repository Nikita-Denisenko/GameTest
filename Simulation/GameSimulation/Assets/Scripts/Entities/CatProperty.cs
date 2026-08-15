using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.Entities
{
    public class CatProperty
    {
        public string Name { get; private set; } = string.Empty;
        public int StatId { get; private set; }
        public CatStatType StatType { get; private set; }
        public float Value { get; private set; }

        public CatProperty(
            string name,
            int statId,
            CatStatType statType,
            float value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitStateException(
                    "Cat property name cannot be empty.");

            if (statId <= 0)
                throw new InvalidUnitStateException(
                    "Cat property StatId must be greater than 0.");

            if (value < 0)
                throw new InvalidUnitStateException(
                    "Cat property value cannot be negative.");

            Name = name;
            StatId = statId;
            StatType = statType;
            Value = value;
        }
    }
}
