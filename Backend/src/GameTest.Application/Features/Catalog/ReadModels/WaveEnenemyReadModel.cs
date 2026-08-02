namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record WaveEnemyReadModel
    {
        public int EnemyId { get; init; }
        public EnemyQuantityRangeReadModel QuantityRange { get; init; } = null!;
        public int SpawnInterval { get; init; }
    }
}
