using GameTest.Application.Interfaces;
using GameTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class CatSeeder
{
    private readonly IAppDbContext _context;
    private readonly ICatFactory _catFactory;

    public CatSeeder(
        IAppDbContext context,
        ICatFactory catFactory)
    {
        _context = context;
        _catFactory = catFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Cats.AnyAsync(ct))
            return;

        var stats = await _context.CatStats
            .ToDictionaryAsync(stat => stat.Type, ct);

        var cats = new[]
        {
            _catFactory.Create(
                "British Shorthair",
                "A calm and sturdy cat that increases health and armor.",
                CatType.BritishShorthair,
                500,
                [
                    (stats[CatStatType.MaxHealth], 20f),
                    (stats[CatStatType.Armor], 5f)
                ]),

            _catFactory.Create(
                "Maine Coon",
                "A large cat that greatly increases health and damage.",
                CatType.MaineCoon,
                750,
                [
                    (stats[CatStatType.MaxHealth], 35f),
                    (stats[CatStatType.Damage], 10f)
                ]),

            _catFactory.Create(
                "Siamese",
                "A fast and agile cat that improves attack and movement speed.",
                CatType.Siamese,
                650,
                [
                    (stats[CatStatType.AttackSpeed], 10f),
                    (stats[CatStatType.MovementSpeed], 8f)
                ]),

            _catFactory.Create(
                "Bengal",
                "An aggressive cat with increased damage and critical chance.",
                CatType.Bengal,
                900,
                [
                    (stats[CatStatType.Damage], 15f),
                    (stats[CatStatType.CritChance], 5f),
                    (stats[CatStatType.CritDamage], 10f)
                ]),

            _catFactory.Create(
                "Sphynx",
                "A unique cat that improves health regeneration and pickup radius.",
                CatType.Sphynx,
                800,
                [
                    (stats[CatStatType.HealthRegen], 3f),
                    (stats[CatStatType.PickupRadius], 15f)
                ]),

            _catFactory.Create(
                "Scottish Fold",
                "A lucky cat that increases experience and gold gain.",
                CatType.ScottishFold,
                700,
                [
                    (stats[CatStatType.ExperienceMultiplier], 10f),
                    (stats[CatStatType.GoldMultiplier], 10f),
                    (stats[CatStatType.Luck], 5f)
                ]),

            _catFactory.Create(
                "Persian",
                "A peaceful cat that provides strong health regeneration.",
                CatType.Persian,
                600,
                [
                    (stats[CatStatType.MaxHealth], 15f),
                    (stats[CatStatType.HealthRegen], 5f)
                ]),

            _catFactory.Create(
                "Ragdoll",
                "A balanced cat that provides several useful combat bonuses.",
                CatType.Ragdoll,
                1000,
                [
                    (stats[CatStatType.MaxHealth], 15f),
                    (stats[CatStatType.Damage], 8f),
                    (stats[CatStatType.MovementSpeed], 5f),
                    (stats[CatStatType.Luck], 3f)
                ])
        };

        await _context.Cats.AddRangeAsync(cats, ct);
        await _context.SaveChangesAsync(ct);
    }
}
