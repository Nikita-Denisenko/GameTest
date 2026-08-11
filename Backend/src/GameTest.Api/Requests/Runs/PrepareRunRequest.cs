using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Runs
{
    public record PrepareRunRequest
    {
        [Range(1, int.MaxValue)]
        public int PlayerUnitId { get; init; }

        [Range(1, int.MaxValue)]
        public int ArenaId { get; init; }

        [Range(1, int.MaxValue)]
        public int? CatId { get; init; }
    }
}
