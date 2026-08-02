using Assets.Scripts.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.ValueObjects
{
    public class EnemyLoot
    {
        public GoldRange Gold { get; }
        public ExperienceRange Experience { get; }

        private readonly List<ItemDrop> _items =
            new List<ItemDrop>();

        public IReadOnlyCollection<ItemDrop> Items
            => _items;

        public EnemyLoot(
            GoldRange gold,
            ExperienceRange experience,
            IEnumerable<ItemDrop> items)
        {
            if (gold == null)
                throw new InvalidValueObjectException(
                    "Gold range cannot be null.");

            if (experience == null)
                throw new InvalidValueObjectException(
                    "Experience range cannot be null.");

            if (items == null || !items.Any())
                throw new InvalidValueObjectException(
                    "Enemy loot must contain at least one item.");

            Gold = gold;
            Experience = experience;
            _items.AddRange(items);
        }
    }
}
