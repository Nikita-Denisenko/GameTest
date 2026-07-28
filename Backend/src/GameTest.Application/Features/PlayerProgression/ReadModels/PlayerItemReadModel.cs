using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerItemReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public ItemType Type { get; init; }
        public float Bonus { get; init; }
        public int Level { get; init; }
        public int? NextLevelPrice { get; init; }
        public float? NextLevelBonus { get; init; }
        public int MaxLevel { get; init; }
        public PlayerItemEffectReadModel Effect { get; init; } = null!;
    }
}
