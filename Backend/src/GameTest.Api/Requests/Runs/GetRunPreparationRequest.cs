using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Runs
{
    public record GetRunPreparationRequest
    {
        [Range(1, int.MaxValue)]
        public int PlayerUnitId { get; init; }

        [Range(1, int.MaxValue)]
        public int ArenaId { get; init; }
    }
}
