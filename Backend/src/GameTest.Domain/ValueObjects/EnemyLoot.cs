using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record EnemyLoot
    {
        public GoldRange Gold { get; init; } = null!;
        public ExperienceRange Experience { get; init; } = null!;

        private readonly List<ItemDrop> _items = [];
        public IReadOnlyCollection<ItemDrop> Items => _items;

        private EnemyLoot()
        {
        }

        public EnemyLoot(
            GoldRange gold, 
            ExperienceRange experience, 
            IEnumerable<ItemDrop> items)
        {
            if (items == null || !items.Any())
                throw new DomainException("Items cannot be empty.");

            Gold = gold;
            Experience = experience;
            _items.AddRange(items);
        }
    }
}


