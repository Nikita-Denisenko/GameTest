using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record ItemEffectReadModel
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemEffectType Type { get; init; }
        public List<LevelProgressionReadModel> Levels { get; init; } = new();
    }
}
