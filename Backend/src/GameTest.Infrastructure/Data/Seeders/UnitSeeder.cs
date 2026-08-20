using GameTest.Application.Interfaces;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class UnitSeeder
{
    private readonly IAppDbContext _context;
    private readonly IUnitFactory _unitFactory;

    public UnitSeeder(
        IAppDbContext context,
        IUnitFactory unitFactory)
    {
        _context = context;
        _unitFactory = unitFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Units.AnyAsync(ct))
            return;

        var stats = await _context.UnitStats
            .ToDictionaryAsync(stat => stat.Type, ct);

        var weapons = await _context.Weapons
            .ToDictionaryAsync(weapon => weapon.Type, ct);

        var units = new[]
        {
            _unitFactory.Create(
                "Warrior",
                "A durable melee fighter with high health and increased damage.",
                UnitType.Warrior,
                weapons[WeaponType.Sword],
                "Strength",
                "Increases damage dealt by the warrior.",
                10f,
                PassiveAbilityType.IncreasedDamage,
                [
                    (
                        stats[UnitStatType.MaxHealth],
                        CreateLevels(
                            (100f, 0),
                            (150f, 200),
                            (200f, 350),
                            (250f, 550),
                            (300f, 800)),
                        CreateTemporaryLevels(20f)
                    ),
                    (
                        stats[UnitStatType.Damage],
                        CreateLevels(
                            (10f, 0),
                            (20f, 200),
                            (30f, 350),
                            (40f, 550),
                            (50f, 800)),
                        CreateTemporaryLevels(5f)
                    ),
                    (
                        stats[UnitStatType.Armor],
                        CreateLevels(
                            (5f, 0),
                            (10f, 200),
                            (15f, 350),
                            (20f, 550),
                            (25f, 800)),
                        CreateTemporaryLevels(2f)
                    ),
                    (
                        stats[UnitStatType.MoveSpeed],
                        CreateLevels(
                            (2.5f, 0),
                            (3f, 200),
                            (3.5f, 350),
                            (4f, 550),
                            (4.5f, 800)),
                        CreateTemporaryLevels(0.25f)
                    )
                ],
                CreateUpgradeLevels()),

            _unitFactory.Create(
                "Mage",
                "A ranged spellcaster with high attack speed and projectile power.",
                UnitType.Mage,
                weapons[WeaponType.Staff],
                "Arcane Power",
                "Increases the mage's maximum health.",
                15f,
                PassiveAbilityType.IncreasedHealth,
                [
                    (
                        stats[UnitStatType.MaxHealth],
                        CreateLevels(
                            (70f, 0),
                            (100f, 200),
                            (130f, 350),
                            (160f, 550),
                            (200f, 800)),
                        CreateTemporaryLevels(15f)
                    ),
                    (
                        stats[UnitStatType.Damage],
                        CreateLevels(
                            (15f, 0),
                            (25f, 200),
                            (35f, 350),
                            (45f, 550),
                            (60f, 800)),
                        CreateTemporaryLevels(5f)
                    ),
                    (
                        stats[UnitStatType.AttackSpeed],
                        CreateLevels(
                            (1.2f, 0),
                            (1.4f, 200),
                            (1.6f, 350),
                            (1.8f, 550),
                            (2f, 800)),
                        CreateTemporaryLevels(0.1f)
                    ),
                    (
                        stats[UnitStatType.ProjectileSpeed],
                        CreateLevels(
                            (5f, 0),
                            (6f, 200),
                            (7f, 350),
                            (8f, 550),
                            (10f, 800)),
                        CreateTemporaryLevels(0.5f)
                    )
                ],
                CreateUpgradeLevels())
        };

        await _context.Units.AddRangeAsync(units, ct);
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
