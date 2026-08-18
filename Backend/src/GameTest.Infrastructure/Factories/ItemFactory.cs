using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Infrastructure.Factories;

public class ItemFactory : IItemFactory
{
    public Item Create(
        string name,
        string description,
        ItemType type,
        string effectName,
        string effectDescription,
        ItemEffectType effectType,
        IEnumerable<LevelProgression> levels,
        IEnumerable<ItemTemporaryLevel> temporaryLevels)
    {
        return new Item(
            name,
            description,
            type,
            effectName,
            effectDescription,
            effectType,
            levels,
            temporaryLevels);
    }
}
