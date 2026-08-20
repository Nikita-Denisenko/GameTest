using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class EnemyStatSeeder
{
    private readonly IAppDbContext _context;

    public EnemyStatSeeder(IAppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.EnemyStats.AnyAsync(ct))
            return;

        var stats = new[]
        {
            new EnemyStat(
                "Max Health",
                "Maximum health of the enemy.",
                EnemyStatType.MaxHealth),

            new EnemyStat(
                "Damage",
                "Enemy attack damage.",
                EnemyStatType.Damage),

            new EnemyStat(
                "Movement Speed",
                "Enemy movement speed.",
                EnemyStatType.MovementSpeed),

            new EnemyStat(
                "Attack Speed",
                "Enemy attack speed.",
                EnemyStatType.AttackSpeed),

            new EnemyStat(
                "Attack Range",
                "Enemy attack range.",
                EnemyStatType.AttackRange),

            new EnemyStat(
                "Projectile Speed",
                "Enemy projectile movement speed.",
                EnemyStatType.ProjectileSpeed),

            new EnemyStat(
                "Critical Chance",
                "Chance for the enemy to deal critical damage.",
                EnemyStatType.CriticalChance),

            new EnemyStat(
                "Critical Damage",
                "Damage multiplier of a critical hit.",
                EnemyStatType.CriticalDamage),

            new EnemyStat(
                "Armor",
                "Enemy damage reduction from armor.",
                EnemyStatType.Armor),

            new EnemyStat(
                "Knockback Resistance",
                "Enemy resistance to knockback effects.",
                EnemyStatType.KnockbackResistance),

            new EnemyStat(
                "Size",
                "Enemy size.",
                EnemyStatType.Size),

            new EnemyStat(
                "Experience Reward",
                "Experience awarded for defeating the enemy.",
                EnemyStatType.ExperienceReward),

            new EnemyStat(
                "Gold Reward",
                "Gold awarded for defeating the enemy.",
                EnemyStatType.GoldReward)
        };

        await _context.EnemyStats.AddRangeAsync(stats, ct);
        await _context.SaveChangesAsync(ct);
    }
}
