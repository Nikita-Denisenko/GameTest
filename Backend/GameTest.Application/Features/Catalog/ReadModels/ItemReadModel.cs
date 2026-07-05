using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record ItemReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemType Type { get; init; }
        public int MaxLevel { get; init; }
        public string EffectName { get; init; } = string.Empty;
        public string EffectDescription { get; init; } = string.Empty;
        public ItemEffectType EffectType { get; init; }
        public List<ItemLevel> Levels { get; init; } = [];
    }
}
