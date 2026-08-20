using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class CatStatSeeder
{
    private readonly IAppDbContext _context;

    public CatStatSeeder(IAppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.CatStats.AnyAsync(ct))
            return;

        var stats = new[]
        {
            new CatStat(
                "Max Health",
                "Maximum health bonus provided by the cat.",
                CatStatType.MaxHealth),

            new CatStat(
                "Damage",
                "Damage bonus provided by the cat.",
                CatStatType.Damage),

            new CatStat(
                "Attack Speed",
                "Attack speed bonus provided by the cat.",
                CatStatType.AttackSpeed),

            new CatStat(
                "Movement Speed",
                "Movement speed bonus provided by the cat.",
                CatStatType.MovementSpeed),

            new CatStat(
                "Health Regen",
                "Health regeneration bonus provided by the cat.",
                CatStatType.HealthRegen),

            new CatStat(
                "Pickup Radius",
                "Pickup radius bonus provided by the cat.",
                CatStatType.PickupRadius),

            new CatStat(
                "Experience Multiplier",
                "Experience gain multiplier provided by the cat.",
                CatStatType.ExperienceMultiplier),

            new CatStat(
                "Gold Multiplier",
                "Gold gain multiplier provided by the cat.",
                CatStatType.GoldMultiplier),

            new CatStat(
                "Luck",
                "Luck bonus provided by the cat.",
                CatStatType.Luck),

            new CatStat(
                "Critical Chance",
                "Critical hit chance bonus provided by the cat.",
                CatStatType.CritChance),

            new CatStat(
                "Critical Damage",
                "Critical damage bonus provided by the cat.",
                CatStatType.CritDamage)
        };

        await _context.CatStats.AddRangeAsync(stats, ct);
        await _context.SaveChangesAsync(ct);
    }
}
