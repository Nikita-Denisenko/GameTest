using Assets.Scripts.Entities;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class EnemyFactory
    {
        private readonly MovementStrategyFactory _movementStrategyFactory;

        public EnemyFactory(
            MovementStrategyFactory movementStrategyFactory)
        {
            _movementStrategyFactory = movementStrategyFactory;
        }


        public Enemy Create(
            EnemyData data,
            IEnumerable<EnemyStatData> stats,
            Vector2 position)
        {
            var properties = data.Properties
                .Select(x =>
                {
                    var stat = stats
                        .First(s => s.Id == x.StatId);

                    return new EnemyStaticProperty(
                        stat.Name,
                        stat.Id,
                        stat.Type,
                        x.Value);
                })
                .ToList();


            var loot = new EnemyLoot(
                new GoldRange(
                    data.Loot.Gold.Min,
                    data.Loot.Gold.Max),

                new ExperienceRange(
                    data.Loot.Experience.Min,
                    data.Loot.Experience.Max),

                data.Loot.Items
                    .Select(x => new ItemDrop(
                        x.ItemId,
                        x.Chance))
                    .ToList());


            var movement = _movementStrategyFactory.Create(
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
                movement);
        }
    }
}
