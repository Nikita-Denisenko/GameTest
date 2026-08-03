using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class EnemyLootData
    {
        public GoldRangeData Gold { get; }
        public ExperienceRangeData Experience { get; }
        public IReadOnlyCollection<ItemDropData> Items { get; }

        public EnemyLootData(
            GoldRangeData gold,
            ExperienceRangeData experience,
            IReadOnlyCollection<ItemDropData> items)
        {
            Gold = gold ?? throw new InvalidEnemyStateException("Gold range cannot be null.");
            Experience = experience ?? throw new InvalidEnemyStateException("Experience range cannot be null.");
            Items = items ?? throw new InvalidEnemyStateException("Items collection cannot be null.");
        }
    }
}