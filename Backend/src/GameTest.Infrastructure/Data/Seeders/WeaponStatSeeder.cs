using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class WeaponStatSeeder
{
    private readonly IAppDbContext _context;

    public WeaponStatSeeder(IAppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.WeaponStats.AnyAsync(ct))
            return;

        var stats = new[]
        {
            new WeaponStat(
                "Damage",
                "Weapon damage.",
                WeaponStatType.Damage),

            new WeaponStat(
                "Cooldown",
                "Time between attacks.",
                WeaponStatType.Cooldown),

            new WeaponStat(
                "Projectile Count",
                "Number of projectiles fired.",
                WeaponStatType.ProjectileCount),

            new WeaponStat(
                "Projectile Speed",
                "Projectile movement speed.",
                WeaponStatType.ProjectileSpeed),

            new WeaponStat(
                "Size",
                "Projectile or attack size.",
                WeaponStatType.Size),

            new WeaponStat(
                "Piercing",
                "Number of enemies a projectile can pierce.",
                WeaponStatType.Piercing),

            new WeaponStat(
                "Ricochet",
                "Number of times a projectile can ricochet.",
                WeaponStatType.Ricochet),

            new WeaponStat(
                "Explosion Radius",
                "Radius of the explosion.",
                WeaponStatType.ExplosionRadius),

            new WeaponStat(
                "Duration",
                "Duration of the weapon effect.",
                WeaponStatType.Duration),

            new WeaponStat(
                "Status Effect",
                "Status effect strength.",
                WeaponStatType.StatusEffect)
        };

        await _context.WeaponStats.AddRangeAsync(stats, ct);
        await _context.SaveChangesAsync(ct);
    }
}
