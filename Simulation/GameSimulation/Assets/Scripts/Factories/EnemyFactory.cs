using Assets.Scripts.Entities;
using Assets.Scripts.GameData;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class EnemyFactory
    {
        private readonly Catalog _catalog;
        private readonly MovementStrategyFactory _movementStrategyFactory;

        public EnemyFactory(
            Catalog catalog,
            MovementStrategyFactory movementStrategyFactory)
        {
            _catalog = catalog;
            _movementStrategyFactory = movementStrategyFactory;
        }

        public Enemy Create(
            EnemyData data,
            Vector2 position)
        {
            var properties = data.Properties
                .Select(CreateStaticProperty)
                .ToList();

            var loot = CreateLoot(data.Loot);

            var movementStrategy =
                _movementStrategyFactory.Create(
                    data.MovementType);

            return new Enemy(
                data.Id,
                position,
                data.Name,
                data.EnemyType,
                data.AttackType,
                properties,
                loot,
                data.MovementType,
                movementStrategy);
        }

        public IReadOnlyCollection<Enemy> CreateMany(
            IEnumerable<EnemyData> data,
            Vector2 position)
        {
            return data
                .Select(x => Create(x, position))
                .ToList();
        }

        private EnemyStaticProperty CreateStaticProperty(
            EnemyPropertyData data)
        {
            var stat = _catalog.EnemyStats[data.StatId];

            return new EnemyStaticProperty(
                stat.Name,
                stat.Id,
                stat.Type,
                data.Value);
        }

        private EnemyLoot CreateLoot(
            EnemyLootData data)
        {
            var gold = new GoldRange(
                data.Gold.Min,
                data.Gold.Max);

            var experience = new ExperienceRange(
                data.Experience.Min,
                data.Experience.Max);

            var items = data.Items
                .Select(CreateItemDrop)
                .ToList();

            return new EnemyLoot(
                gold,
                experience,
                items);
        }

        private ItemDrop CreateItemDrop(
            ItemDropData data)
        {
            return new ItemDrop(
                data.ItemId,
                data.Chance);
        }
    }
}
