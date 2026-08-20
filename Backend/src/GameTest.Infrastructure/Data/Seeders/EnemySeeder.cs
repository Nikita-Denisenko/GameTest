using GameTest.Application.Interfaces;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class EnemySeeder
{
    private readonly IAppDbContext _context;
    private readonly IEnemyFactory _enemyFactory;

    public EnemySeeder(
        IAppDbContext context,
        IEnemyFactory enemyFactory)
    {
        _context = context;
        _enemyFactory = enemyFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Enemies.AnyAsync(ct))
            return;

        var stats = await _context.EnemyStats
            .ToDictionaryAsync(stat => stat.Type, ct);

        var enemies = new[]
        {
            _enemyFactory.Create(
                "Goblin",
                "A weak but aggressive creature that attacks the player in close combat.",
                EnemyType.Normal,
                EnemyAttackType.Melee,
                EnemyMovementType.FollowPlayer,
                [
                    (stats[EnemyStatType.MaxHealth], 50f),
                    (stats[EnemyStatType.Damage], 8f),
                    (stats[EnemyStatType.MovementSpeed], 2.5f),
                    (stats[EnemyStatType.AttackSpeed], 1f),
                    (stats[EnemyStatType.AttackRange], 1.5f),
                    (stats[EnemyStatType.Armor], 0f),
                    (stats[EnemyStatType.KnockbackResistance], 0f),
                    (stats[EnemyStatType.Size], 1f)
                ],
                new GoldRange(1, 3),
                new ExperienceRange(5, 10),
                [
                    new ItemDrop(1, 0.05f)
                ]),

            _enemyFactory.Create(
                "Wolf",
                "A fast predator that quickly closes the distance to its target.",
                EnemyType.Fast,
                EnemyAttackType.Melee,
                EnemyMovementType.FollowPlayer,
                [
                    (stats[EnemyStatType.MaxHealth], 75f),
                    (stats[EnemyStatType.Damage], 12f),
                    (stats[EnemyStatType.MovementSpeed], 4f),
                    (stats[EnemyStatType.AttackSpeed], 1.5f),
                    (stats[EnemyStatType.AttackRange], 1.5f),
                    (stats[EnemyStatType.Armor], 2f),
                    (stats[EnemyStatType.KnockbackResistance], 10f),
                    (stats[EnemyStatType.Size], 1f)
                ],
                new GoldRange(2, 5),
                new ExperienceRange(10, 18),
                [
                    new ItemDrop(1, 0.08f)
                ]),

            _enemyFactory.Create(
                "Skeleton Archer",
                "A ranged enemy that keeps its distance and fires projectiles at the player.",
                EnemyType.Ranged,
                EnemyAttackType.Ranged,
                EnemyMovementType.KeepDistance,
                [
                    (stats[EnemyStatType.MaxHealth], 60f),
                    (stats[EnemyStatType.Damage], 10f),
                    (stats[EnemyStatType.MovementSpeed], 2f),
                    (stats[EnemyStatType.AttackSpeed], 0.8f),
                    (stats[EnemyStatType.AttackRange], 10f),
                    (stats[EnemyStatType.ProjectileSpeed], 7f),
                    (stats[EnemyStatType.CriticalChance], 5f),
                    (stats[EnemyStatType.CriticalDamage], 150f),
                    (stats[EnemyStatType.Armor], 1f),
                    (stats[EnemyStatType.KnockbackResistance], 5f),
                    (stats[EnemyStatType.Size], 1f)
                ],
                new GoldRange(3, 7),
                new ExperienceRange(12, 22),
                [
                    new ItemDrop(1, 0.1f)
                ]),

            _enemyFactory.Create(
                "Orc",
                "A heavily armored warrior with high health and strong resistance to knockback.",
                EnemyType.Tank,
                EnemyAttackType.Melee,
                EnemyMovementType.FollowPlayer,
                [
                    (stats[EnemyStatType.MaxHealth], 250f),
                    (stats[EnemyStatType.Damage], 25f),
                    (stats[EnemyStatType.MovementSpeed], 1.5f),
                    (stats[EnemyStatType.AttackSpeed], 0.7f),
                    (stats[EnemyStatType.AttackRange], 2f),
                    (stats[EnemyStatType.Armor], 12f),
                    (stats[EnemyStatType.KnockbackResistance], 75f),
                    (stats[EnemyStatType.Size], 1.5f)
                ],
                new GoldRange(8, 15),
                new ExperienceRange(30, 50),
                [
                    new ItemDrop(1, 0.15f)
                ]),

            _enemyFactory.Create(
                "Demon",
                "An elite creature capable of dealing devastating explosive attacks.",
                EnemyType.Elite,
                EnemyAttackType.Explosive,
                EnemyMovementType.FollowPlayer,
                [
                    (stats[EnemyStatType.MaxHealth], 500f),
                    (stats[EnemyStatType.Damage], 40f),
                    (stats[EnemyStatType.MovementSpeed], 2f),
                    (stats[EnemyStatType.AttackSpeed], 0.5f),
                    (stats[EnemyStatType.AttackRange], 6f),
                    (stats[EnemyStatType.ProjectileSpeed], 5f),
                    (stats[EnemyStatType.CriticalChance], 10f),
                    (stats[EnemyStatType.CriticalDamage], 200f),
                    (stats[EnemyStatType.Armor], 15f),
                    (stats[EnemyStatType.KnockbackResistance], 90f),
                    (stats[EnemyStatType.Size], 2f)
                ],
                new GoldRange(20, 40),
                new ExperienceRange(75, 120),
                [
                    new ItemDrop(1, 0.25f)
                ])
        };

        await _context.Enemies.AddRangeAsync(enemies, ct);
        await _context.SaveChangesAsync(ct);
    }
}
