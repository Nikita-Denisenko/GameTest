using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.Exceptions.Domain;

namespace Assets.Scripts.GameData.StaticData
{
    public class CatStatData
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public CatStatType Type { get; }

        public CatStatData(
            int id,
            string name,
            string description,
            CatStatType type)
        {
            if (id <= 0)
                throw new InvalidCatStateException("CatStat Id must be positive");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCatStateException("CatStat name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidCatStateException("CatStat description cannot be empty.");

            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
