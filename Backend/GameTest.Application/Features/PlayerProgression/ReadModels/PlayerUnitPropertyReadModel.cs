using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerUnitPropertyReadModel
    {
        public int Id { get; init; }
        public int StatId { get; init; }
        public string StatName { get; init; } = null!;
        public UnitStatType StatType { get; init; }
        public double Value { get; init; }
        public int Level { get; init; }
        public double? NextLevelValue { get; init; }
        public int? NextLevelPrice { get; init; }
        public int MaxLevel { get; init; }
    }
}
