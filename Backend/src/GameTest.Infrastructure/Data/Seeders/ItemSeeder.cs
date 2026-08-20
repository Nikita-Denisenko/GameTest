using GameTest.Application.Interfaces;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class ItemSeeder
{
    private readonly IAppDbContext _context;
    private readonly IItemFactory _itemFactory;

    public ItemSeeder(
        IAppDbContext context,
        IItemFactory itemFactory)
    {
        _context = context;
        _itemFactory = itemFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Items.AnyAsync(ct))
            return;

        var items = new[]
        {
            _itemFactory.Create(
                "Gloves",
                "Increases attack speed.",
                ItemType.Gloves,
                "Attack Speed",
                "Increases the player's attack speed.",
                ItemEffectType.AttackSpeed,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 200),
                    new LevelProgression(3, 15f, 350),
                    new LevelProgression(4, 20f, 550),
                    new LevelProgression(5, 30f, 800)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Boots",
                "Increases movement speed.",
                ItemType.Boots,
                "Movement Speed",
                "Increases the player's movement speed.",
                ItemEffectType.MoveSpeed,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 200),
                    new LevelProgression(3, 15f, 350),
                    new LevelProgression(4, 20f, 550),
                    new LevelProgression(5, 30f, 800)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Book",
                "Increases experience gained.",
                ItemType.Book,
                "Experience Gain",
                "Increases the amount of experience gained from enemies.",
                ItemEffectType.ExperienceGain,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Coin Purse",
                "Increases gold gained.",
                ItemType.CoinPurse,
                "Gold Gain",
                "Increases the amount of gold gained from enemies.",
                ItemEffectType.GoldGain,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Amulet",
                "Increases damage dealt.",
                ItemType.Amulet,
                "Damage",
                "Increases the player's damage.",
                ItemEffectType.Damage,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 300),
                    new LevelProgression(3, 15f, 500),
                    new LevelProgression(4, 20f, 750),
                    new LevelProgression(5, 30f, 1100)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Crystal",
                "Increases critical hit chance.",
                ItemType.Crystal,
                "Critical Chance",
                "Increases the chance to deal a critical hit.",
                ItemEffectType.CritChance,
                [
                    new LevelProgression(1, 2f, 0),
                    new LevelProgression(2, 4f, 300),
                    new LevelProgression(3, 6f, 500),
                    new LevelProgression(4, 8f, 750),
                    new LevelProgression(5, 12f, 1100)
                ],
                CreateTemporaryLevels(2f)),

            _itemFactory.Create(
                "Cloak",
                "Increases armor and defensive capabilities.",
                ItemType.Cloak,
                "Armor",
                "Increases the player's armor.",
                ItemEffectType.Armor,
                [
                    new LevelProgression(1, 3f, 0),
                    new LevelProgression(2, 6f, 300),
                    new LevelProgression(3, 9f, 500),
                    new LevelProgression(4, 12f, 750),
                    new LevelProgression(5, 18f, 1100)
                ],
                CreateTemporaryLevels(3f)),

            _itemFactory.Create(
                "Heart",
                "Increases maximum health.",
                ItemType.Heart,
                "Maximum Health",
                "Increases the player's maximum health.",
                ItemEffectType.MaxHealth,
                [
                    new LevelProgression(1, 20f, 0),
                    new LevelProgression(2, 40f, 300),
                    new LevelProgression(3, 60f, 500),
                    new LevelProgression(4, 80f, 750),
                    new LevelProgression(5, 120f, 1100)
                ],
                CreateTemporaryLevels(20f)),

            _itemFactory.Create(
                "Ring",
                "Increases pickup radius.",
                ItemType.Ring,
                "Pickup Radius",
                "Increases the radius for collecting experience and gold.",
                ItemEffectType.PickupRadius,
                [
                    new LevelProgression(1, 10f, 0),
                    new LevelProgression(2, 20f, 200),
                    new LevelProgression(3, 30f, 350),
                    new LevelProgression(4, 40f, 550),
                    new LevelProgression(5, 60f, 800)
                ],
                CreateTemporaryLevels(10f)),

            _itemFactory.Create(
                "Orb",
                "Increases attack area.",
                ItemType.Orb,
                "Attack Area",
                "Increases the area of attacks and projectiles.",
                ItemEffectType.AttackArea,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Clock",
                "Increases effect duration.",
                ItemType.Clock,
                "Effect Duration",
                "Increases the duration of temporary effects.",
                ItemEffectType.EffectDuration,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Skull",
                "Increases enemy spawn rate and rewards.",
                ItemType.Skull,
                "Enemy Spawn Rate",
                "Increases the number of enemies spawned during a run.",
                ItemEffectType.EnemySpawnRate,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 300),
                    new LevelProgression(3, 15f, 500),
                    new LevelProgression(4, 20f, 750),
                    new LevelProgression(5, 30f, 1100)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Clover",
                "Increases luck.",
                ItemType.Clover,
                "Luck",
                "Increases the player's luck.",
                ItemEffectType.Luck,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Mask",
                "Increases life steal.",
                ItemType.Mask,
                "Vampirism",
                "Restores a portion of health when dealing damage.",
                ItemEffectType.Vampirism,
                [
                    new LevelProgression(1, 2f, 0),
                    new LevelProgression(2, 4f, 300),
                    new LevelProgression(3, 6f, 500),
                    new LevelProgression(4, 8f, 750),
                    new LevelProgression(5, 12f, 1100)
                ],
                CreateTemporaryLevels(2f)),

            _itemFactory.Create(
                "Feather",
                "Increases projectile speed.",
                ItemType.Feather,
                "Projectile Speed",
                "Increases the speed of projectiles.",
                ItemEffectType.ProjectileSpeed,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 200),
                    new LevelProgression(3, 15f, 350),
                    new LevelProgression(4, 20f, 550),
                    new LevelProgression(5, 30f, 800)
                ],
                CreateTemporaryLevels(5f)),

            _itemFactory.Create(
                "Compass",
                "Increases attack range.",
                ItemType.Compass,
                "Attack Range",
                "Increases the range of attacks.",
                ItemEffectType.AttackRange,
                [
                    new LevelProgression(1, 5f, 0),
                    new LevelProgression(2, 10f, 250),
                    new LevelProgression(3, 15f, 400),
                    new LevelProgression(4, 20f, 600),
                    new LevelProgression(5, 30f, 900)
                ],
                CreateTemporaryLevels(5f))
        };

        await _context.Items.AddRangeAsync(items, ct);
        await _context.SaveChangesAsync(ct);
    }

    private static IEnumerable<ItemTemporaryLevel> CreateTemporaryLevels(
        float baseBonus)
    {
        return
        [
            new ItemTemporaryLevel(1, baseBonus, 0),
            new ItemTemporaryLevel(2, baseBonus * 2, 100),
            new ItemTemporaryLevel(3, baseBonus * 3, 175),
            new ItemTemporaryLevel(4, baseBonus * 4, 275),
            new ItemTemporaryLevel(5, baseBonus * 6, 400)
        ];
    }
}
