namespace GameTest.Application.Features.Runs.ReadModels
{
    public class RunPreparationReadModel
    {
        public int ArenaId { get; init; }
        public int PlayerId { get; init; }
        public IReadOnlyCollection<RunWeaponReadModel> Weapons { get; init; } = [];
        public IReadOnlyCollection<RunItemReadModel> Items { get; init; } = [];
        public RunUnitReadModel Unit { get; init; } = null!;
        public RunCatReadModel? Cat { get; init; }
    }
}
