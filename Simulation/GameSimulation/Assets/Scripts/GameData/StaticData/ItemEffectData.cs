using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class ItemEffectData
    {
        public string Name { get; }
        public string Description { get; }
        public ItemEffectType Type { get; }

        public ItemEffectData(
            string name,
            string description,
            ItemEffectType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidValueObjectException("Effect name cannot be empty.");

            Name = name;
            Description = description ?? string.Empty;
            Type = type;
        }
    }
}
