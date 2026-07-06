using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record WeaponPropertyReadModel
    {
        public int StatId { get; init; }
        public string StatName { get; init; } = string.Empty;
        public List<LevelProgressionReadModel> Levels { get; init; } = [];
    }
}
