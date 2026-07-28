namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunItemReadModel
    {
        public int PlayerItemId { get; init; }
        public int ItemId { get; init; }
        public float Bonus { get; init; }
        public int Level { get; init; }
    }
}
