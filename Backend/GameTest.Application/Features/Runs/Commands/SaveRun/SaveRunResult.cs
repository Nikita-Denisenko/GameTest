namespace GameTest.Application.Features.Runs.Commands.SaveRun
{
    public record SaveRunResult
    {
        public int RunId { get; init; }
        public int NewTotalKills { get; init; }
        public int NewGold { get; init; }
    }
}
