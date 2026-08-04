using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class ItemData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public ItemType Type { get; }
        public int MaxLevel { get; }
        public ItemEffectData Effect { get; }
        public IReadOnlyCollection<ItemTemporaryLevelData> TemporaryLevels { get; }

        public ItemData(
            int id,
            string name,
            string description,
            ItemType type,
            int maxLevel,
            ItemEffectData effect,
            IReadOnlyCollection<ItemTemporaryLevelData> temporaryLevels)
        {
            if (id <= 0)
                throw new InvalidValueObjectException("Item id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidValueObjectException("Item name cannot be empty.");

            if (maxLevel <= 0)
                throw new InvalidValueObjectException("Item max level must be greater than zero.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
            MaxLevel = maxLevel;
            Effect = effect ?? throw new InvalidValueObjectException("Item effect cannot be null.");
            TemporaryLevels = temporaryLevels ?? throw new InvalidValueObjectException("Temporary levels cannot be null.");
        }
    }
}
