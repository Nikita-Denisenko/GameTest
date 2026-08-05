namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record ArenaReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public float Width { get; init; }
        public float Height { get; init; }
    }
}
