namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record WaveReadModel
    {
        public int Id { get; init; }
        public int Number { get; init; }
        public int StartSecond { get; init; }
        public int EndSecond { get; init; }
        public IReadOnlyCollection<WaveEnemyReadModel> Enemies { get; init; } = null!;
    }
}
