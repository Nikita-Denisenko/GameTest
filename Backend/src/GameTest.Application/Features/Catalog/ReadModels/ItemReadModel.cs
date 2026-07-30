using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record ItemReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemType Type { get; init; }
        public int MaxLevel { get; init; }
        public ItemEffectReadModel Effect { get; init; } = null!;
        public IReadOnlyCollection<TemporaryLevelReadModel> TemporaryLevels { get; init; } = null!;
    }
}
