namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record EnemyLootReadModel
    {
        public GoldRangeReadModel Gold { get; init; } = null!;
        public ExperienceRangeReadModel Experience { get; init; } = null!;
        public IReadOnlyCollection<ItemDropReadModel> Items { get; init; } = [];
    }
}
