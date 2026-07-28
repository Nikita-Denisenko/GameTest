namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunWeaponReadModel
    {
        public int PlayerWeaponId { get; init; }
        public int WeaponId { get; init; }
        public IReadOnlyCollection<RunWeaponPropertyReadModel> Properties { get; init; } = [];
    }
}
