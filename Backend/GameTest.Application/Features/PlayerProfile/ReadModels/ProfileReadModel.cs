namespace GameTest.Application.Features.PlayerProfile.ReadModels
{
    public record ProfileReadModel
    {
        public string Nickname { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public DateTime RegisteredAt { get; init; }
        public int Gold { get; init; }
        public int TotalKills { get; init; }
    }
}
