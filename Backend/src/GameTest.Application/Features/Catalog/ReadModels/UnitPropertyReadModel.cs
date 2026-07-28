namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record UnitPropertyReadModel
    {
        public int StatId { get; init; }
        public string StatName { get; init; } = string.Empty;
        public IReadOnlyCollection<LevelProgressionReadModel> Levels { get; init; } = [];
        public IReadOnlyCollection<TemporaryLevelReadModel> TemporaryLevels { get; init; } = [];
    }
}
