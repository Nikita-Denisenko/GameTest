namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record PlayerLevelReadModel
    {
        public int Id { get; init; }
        public int Experience { get; init; }
        public int Level { get; init; }
    }
}
