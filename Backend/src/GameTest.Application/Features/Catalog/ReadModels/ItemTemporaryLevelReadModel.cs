namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record ItemTemporaryLevelReadModel
    {
        public int Level { get; init; }
        public float Bonus { get; init; }
        public int Price { get; init; }
    }
}
