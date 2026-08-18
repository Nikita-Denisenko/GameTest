using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Interfaces;

public interface IEnemyFactory
{
    Enemy Create(
        string name,
        string description,
        EnemyType type,
        EnemyAttackType attackType,
        EnemyMovementType movementType,
        IEnumerable<(EnemyStat Stat, float Value)> properties,
        GoldRange gold,
        ExperienceRange experience,
        IEnumerable<ItemDrop> itemDrops);
}
