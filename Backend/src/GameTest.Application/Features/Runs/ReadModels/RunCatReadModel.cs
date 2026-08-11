using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunCatReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;

        public IReadOnlyCollection<RunCatPropertyReadModel> Properties = [];
        public CatType Type { get; init; }
    }
}
