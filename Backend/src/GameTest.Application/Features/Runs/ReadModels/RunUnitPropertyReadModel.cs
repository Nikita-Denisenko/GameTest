namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunUnitPropertyReadModel
    {
        public int StatId { get; init; }
        public int Level { get; init; }
        public float Value { get; init; }
    }
}
