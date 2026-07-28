namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunUnitReadModel
    {
        public int PlayerUnitId { get; init; }
        public int UnitId { get; init; }
        public IReadOnlyCollection<RunUnitPropertyReadModel> Properties { get; init; } = [];
    }
}
