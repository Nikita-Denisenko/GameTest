using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record CatReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IReadOnlyCollection<CatPropertyReadModel> Properties { get; init; } = null!;
        public CatType Type { get; init; }
        public int Price { get; init; }
    }
}
