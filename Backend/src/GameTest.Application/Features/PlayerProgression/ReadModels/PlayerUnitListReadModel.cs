using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerUnitListReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public UnitType Type { get; init; }
    }
}
