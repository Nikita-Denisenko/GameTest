using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Infrastructure.Factories;

public class EnemyFactory : IEnemyFactory
{
    public Enemy Create(
        string name,
        string description,
        EnemyType type,
        EnemyAttackType attackType,
        EnemyMovementType movementType,
        IEnumerable<(EnemyStat Stat, float Value)> properties,
        GoldRange gold,
        ExperienceRange experience,
        IEnumerable<ItemDrop> itemDrops)
    {
        var enemyProperties = properties
            .Select(property => new EnemyProperty(
                property.Stat,
                property.Value))
            .ToList();

        var loot = new EnemyLoot(
            gold,
            experience,
            itemDrops);

        return new Enemy(
            name,
            description,
            type,
            attackType,
            movementType,
            enemyProperties,
            loot);
    }
}
