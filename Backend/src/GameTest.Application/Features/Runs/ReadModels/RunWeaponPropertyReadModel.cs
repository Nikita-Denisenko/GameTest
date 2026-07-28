namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunWeaponPropertyReadModel
    {
        public int StatId { get; init; }
        public int Level { get; init; }
        public float Value { get; init; }
    }
}
