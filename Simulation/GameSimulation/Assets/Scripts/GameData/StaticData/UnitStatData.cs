using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class UnitStatData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public UnitStatType Type { get; }

        public UnitStatData(
            int id,
            string name,
            string description,
            UnitStatType type)
        {
            if (id <= 0)
                throw new InvalidUnitStateException("Unit stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitStateException("Unit stat name cannot be empty.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
        }
    }
}
