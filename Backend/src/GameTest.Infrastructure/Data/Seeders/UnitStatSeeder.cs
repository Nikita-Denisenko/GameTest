using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class UnitStatSeeder
{
    private readonly IAppDbContext _context;

    public UnitStatSeeder(IAppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.UnitStats.AnyAsync(ct))
            return;

        var stats = new[]
        {
            new UnitStat(
                "Max Health",
                "Maximum amount of health.",
                UnitStatType.MaxHealth),

            new UnitStat(
                "Damage",
                "Damage dealt by the unit.",
                UnitStatType.Damage),

            new UnitStat(
                "Armor",
                "Reduces incoming damage.",
                UnitStatType.Armor),

            new UnitStat(
                "Move Speed",
                "Movement speed of the unit.",
                UnitStatType.MoveSpeed),

            new UnitStat(
                "Health Regen",
                "Health regenerated over time.",
                UnitStatType.HealthRegen),

            new UnitStat(
                "Attack Speed",
                "Attack speed of the unit.",
                UnitStatType.AttackSpeed),

            new UnitStat(
                "Area Size",
                "Size of attacks and effects.",
                UnitStatType.AreaSize),

            new UnitStat(
                "Projectile Speed",
                "Speed of projectiles.",
                UnitStatType.ProjectileSpeed),

            new UnitStat(
                "Effect Duration",
                "Duration of applied effects.",
                UnitStatType.EffectDuration),

            new UnitStat(
                "Crit Chance",
                "Chance to deal critical damage.",
                UnitStatType.CritChance),

            new UnitStat(
                "Crit Damage",
                "Additional damage dealt by critical hits.",
                UnitStatType.CritDamage),

            new UnitStat(
                "Life Steal",
                "Amount of health restored from dealt damage.",
                UnitStatType.LifeSteal),

            new UnitStat(
                "Luck",
                "Affects luck-based game mechanics.",
                UnitStatType.Luck),

            new UnitStat(
                "Pickup Radius",
                "Radius within which items can be picked up.",
                UnitStatType.PickupRadius),

            new UnitStat(
                "Experience Multiplier",
                "Multiplier applied to gained experience.",
                UnitStatType.ExperienceMultiplier),

            new UnitStat(
                "Gold Multiplier",
                "Multiplier applied to gained gold.",
                UnitStatType.GoldMultiplier)
        };

        await _context.UnitStats.AddRangeAsync(stats, ct);
        await _context.SaveChangesAsync(ct);
    }
}