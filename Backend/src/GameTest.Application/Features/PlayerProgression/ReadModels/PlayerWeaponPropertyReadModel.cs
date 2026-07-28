using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerWeaponPropertyReadModel
    {
        public int Id { get; init; }
        public int StatId { get; init; }
        public string StatName { get; init; } = null!;
        public WeaponStatType StatType { get; init; }
        public float Value { get; init; }
        public int Level { get; init; }
        public float? NextLevelValue { get; init; }
        public int? NextLevelPrice { get; init; }
        public int MaxLevel { get; init; }
    }
}
