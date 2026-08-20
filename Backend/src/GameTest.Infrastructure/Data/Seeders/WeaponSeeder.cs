using GameTest.Application.Interfaces;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class WeaponSeeder
{
    private readonly IAppDbContext _context;
    private readonly IWeaponFactory _weaponFactory;

    public WeaponSeeder(
        IAppDbContext context,
        IWeaponFactory weaponFactory)
    {
        _context = context;
        _weaponFactory = weaponFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Weapons.AnyAsync(ct))
            return;

        var stats = await _context.WeaponStats
            .ToDictionaryAsync(stat => stat.Type, ct);

        var weapons = new[]
        {
            _weaponFactory.Create(
                "Sword",
                "A balanced melee weapon with reliable damage.",
                WeaponType.Sword,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (20f, 0),
                            (30f, 200),
                            (40f, 350),
                            (50f, 550),
                            (65f, 800)),
                        CreateTemporaryLevels(5f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (1.2f, 0),
                            (1.1f, 200),
                            (1.0f, 350),
                            (0.9f, 550),
                            (0.8f, 800)),
                        CreateTemporaryLevels(0.05f)
                    ),
                    (
                        stats[WeaponStatType.Size],
                        CreateLevels(
                            (1f, 0),
                            (1.1f, 200),
                            (1.2f, 350),
                            (1.3f, 550),
                            (1.5f, 800)),
                        CreateTemporaryLevels(0.05f)
                    ),
                    (
                        stats[WeaponStatType.Piercing],
                        CreateLevels(
                            (1f, 0),
                            (2f, 300),
                            (3f, 500),
                            (4f, 750),
                            (5f, 1100)),
                        CreateTemporaryLevels(1f)
                    )
                ],
                CreateUpgradeLevels()),

            _weaponFactory.Create(
                "Knife",
                "A fast melee weapon with low cooldown.",
                WeaponType.Knife,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (12f, 0),
                            (18f, 200),
                            (24f, 350),
                            (30f, 550),
                            (40f, 800)),
                        CreateTemporaryLevels(3f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (0.7f, 0),
                            (0.65f, 200),
                            (0.6f, 350),
                            (0.55f, 550),
                            (0.5f, 800)),
                        CreateTemporaryLevels(0.03f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileCount],
                        CreateLevels(
                            (1f, 0),
                            (2f, 300),
                            (3f, 500),
                            (4f, 750),
                            (5f, 1100)),
                        CreateTemporaryLevels(1f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileSpeed],
                        CreateLevels(
                            (8f, 0),
                            (9f, 200),
                            (10f, 350),
                            (11f, 550),
                            (13f, 800)),
                        CreateTemporaryLevels(0.5f)
                    )
                ],
                CreateUpgradeLevels()),

            _weaponFactory.Create(
                "Fireball",
                "A powerful projectile that explodes on impact.",
                WeaponType.Fireball,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (25f, 0),
                            (35f, 200),
                            (45f, 350),
                            (60f, 550),
                            (80f, 800)),
                        CreateTemporaryLevels(5f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (1.8f, 0),
                            (1.65f, 200),
                            (1.5f, 350),
                            (1.35f, 550),
                            (1.2f, 800)),
                        CreateTemporaryLevels(0.05f)
                    ),
                    (
                        stats[WeaponStatType.ExplosionRadius],
                        CreateLevels(
                            (1.5f, 0),
                            (1.8f, 250),
                            (2.1f, 400),
                            (2.4f, 600),
                            (3f, 900)),
                        CreateTemporaryLevels(0.1f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileSpeed],
                        CreateLevels(
                            (5f, 0),
                            (6f, 200),
                            (7f, 350),
                            (8f, 550),
                            (10f, 800)),
                        CreateTemporaryLevels(0.5f)
                    )
                ],
                CreateUpgradeLevels()),

            _weaponFactory.Create(
                "Lightning",
                "A lightning weapon that rapidly strikes enemies.",
                WeaponType.Lightning,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (18f, 0),
                            (28f, 200),
                            (38f, 350),
                            (50f, 550),
                            (65f, 800)),
                        CreateTemporaryLevels(4f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (1.4f, 0),
                            (1.25f, 200),
                            (1.1f, 350),
                            (0.95f, 550),
                            (0.8f, 800)),
                        CreateTemporaryLevels(0.05f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileCount],
                        CreateLevels(
                            (1f, 0),
                            (2f, 300),
                            (3f, 500),
                            (4f, 750),
                            (5f, 1100)),
                        CreateTemporaryLevels(1f)
                    ),
                    (
                        stats[WeaponStatType.Size],
                        CreateLevels(
                            (1f, 0),
                            (1.15f, 200),
                            (1.3f, 350),
                            (1.45f, 550),
                            (1.7f, 800)),
                        CreateTemporaryLevels(0.05f)
                    )
                ],
                CreateUpgradeLevels()),

            _weaponFactory.Create(
                "Bow",
                "A ranged weapon that fires fast piercing arrows.",
                WeaponType.Bow,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (15f, 0),
                            (23f, 200),
                            (31f, 350),
                            (40f, 550),
                            (52f, 800)),
                        CreateTemporaryLevels(4f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (1.0f, 0),
                            (0.9f, 200),
                            (0.8f, 350),
                            (0.7f, 550),
                            (0.6f, 800)),
                        CreateTemporaryLevels(0.04f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileSpeed],
                        CreateLevels(
                            (10f, 0),
                            (12f, 200),
                            (14f, 350),
                            (16f, 550),
                            (20f, 800)),
                        CreateTemporaryLevels(0.5f)
                    ),
                    (
                        stats[WeaponStatType.Piercing],
                        CreateLevels(
                            (1f, 0),
                            (2f, 300),
                            (3f, 500),
                            (4f, 750),
                            (5f, 1100)),
                        CreateTemporaryLevels(1f)
                    )
                ],
                CreateUpgradeLevels()),

            _weaponFactory.Create(
                "Staff",
                "A magical ranged weapon that fires multiple projectiles.",
                WeaponType.Staff,
                [
                    (
                        stats[WeaponStatType.Damage],
                        CreateLevels(
                            (10f, 0),
                            (16f, 200),
                            (22f, 350),
                            (30f, 550),
                            (40f, 800)),
                        CreateTemporaryLevels(3f)
                    ),
                    (
                        stats[WeaponStatType.Cooldown],
                        CreateLevels(
                            (1.0f, 0),
                            (0.9f, 200),
                            (0.8f, 350),
                            (0.7f, 550),
                            (0.6f, 800)),
                        CreateTemporaryLevels(0.04f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileCount],
                        CreateLevels(
                            (1f, 0),
                            (2f, 300),
                            (3f, 500),
                            (4f, 750),
                            (5f, 1100)),
                        CreateTemporaryLevels(1f)
                    ),
                    (
                        stats[WeaponStatType.ProjectileSpeed],
                        CreateLevels(
                            (6f, 0),
                            (7f, 200),
                            (8f, 350),
                            (9f, 550),
                            (11f, 800)),
                        CreateTemporaryLevels(0.5f)
                    ),
                    (
                        stats[WeaponStatType.Duration],
                        CreateLevels(
                            (2f, 0),
                            (2.5f, 250),
                            (3f, 400),
                            (3.5f, 600),
                            (4.5f, 900)),
                        CreateTemporaryLevels(0.1f)
                    )
                ],
                CreateUpgradeLevels())
        };

        await _context.Weapons.AddRangeAsync(weapons, ct);
        await _context.SaveChangesAsync(ct);
    }

    private static IEnumerable<LevelProgression> CreateLevels(
        params (float Value, int Price)[] levels)
    {
        return levels.Select((level, index) =>
            new LevelProgression(
                index + 1,
                level.Value,
                level.Price));
    }

    private static IEnumerable<TemporaryLevel> CreateTemporaryLevels(
        float baseBonus)
    {
        return
        [
            new TemporaryLevel(1, baseBonus),
            new TemporaryLevel(2, baseBonus * 2),
            new TemporaryLevel(3, baseBonus * 3),
            new TemporaryLevel(4, baseBonus * 4),
            new TemporaryLevel(5, baseBonus * 5)
        ];
    }

    private static IEnumerable<TemporaryUpgradeLevel> CreateUpgradeLevels()
    {
        return
        [
            new TemporaryUpgradeLevel(1, 0),
            new TemporaryUpgradeLevel(2, 100),
            new TemporaryUpgradeLevel(3, 175),
            new TemporaryUpgradeLevel(4, 275),
            new TemporaryUpgradeLevel(5, 400)
        ];
    }
}
