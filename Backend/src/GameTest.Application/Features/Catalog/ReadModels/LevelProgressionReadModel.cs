namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record LevelProgressionReadModel
    {
        public int Level { get; init; }
        public double Value { get; init; }
        public int Price { get; init; }
    }
}
