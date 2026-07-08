using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerItemEffectReadModel
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public ItemEffectType Type { get; init; }
    }
}
