using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record EnemyPropertyReadModel
    {
        public int StatId { get; init; }
        public string StatName { get; init; } = string.Empty;
        public double Value { get; init; }
    }
}
