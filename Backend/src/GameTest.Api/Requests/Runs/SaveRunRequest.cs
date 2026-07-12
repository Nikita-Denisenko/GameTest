using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Runs;

public record SaveRunRequest
{
    [Required]
    public Guid IdempotencyKey { get; init; }

    [Range(1, int.MaxValue)]
    public int UnitId { get; init; }

    [Required]
    public DateTime StartedAt { get; init; }

    [Range(1, int.MaxValue)]
    public int DurationSeconds { get; init; }

    [Range(0, int.MaxValue)]
    public int Kills { get; init; }

    [Range(0, int.MaxValue)]
    public int GoldEarned { get; init; }

    [Range(1, int.MaxValue)]
    public int LevelReached { get; init; }
}
