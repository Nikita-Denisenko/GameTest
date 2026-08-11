namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record CatPropertyReadModel
    {
        public int StatId { get; init; }
        public string StatName { get; init; } = string.Empty;
        public float Value { get; init; }
    }
}
