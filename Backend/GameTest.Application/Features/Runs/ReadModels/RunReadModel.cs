namespace GameTest.Application.Features.Runs.ReadModels
{
    public record RunReadModel
    {
        public int Id { get; init; }
        public int UnitId { get; init; }
        public string UnitName { get; init; } = null!;
        public DateTime StartedAt { get; init; }
        public int DurationSeconds { get; init; }
        public int Kills { get; init; }
        public int GoldEarned { get; init; }
        public int LevelReached { get; init; }
    }
}
