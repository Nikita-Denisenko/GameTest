using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Interfaces;

public interface IItemFactory
{
    Item Create(
        string name,
        string description,
        ItemType type,
        string effectName,
        string effectDescription,
        ItemEffectType effectType,
        IEnumerable<LevelProgression> levels,
        IEnumerable<ItemTemporaryLevel> temporaryLevels);
}
