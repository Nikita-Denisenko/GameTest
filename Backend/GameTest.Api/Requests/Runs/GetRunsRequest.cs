using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Runs;

public record GetRunsRequest
{
    [Range(1, int.MaxValue)]
    public int Page { get; init; } = 1;

    [Range(1, 100)]
    public int Size { get; init; } = 20;

    public bool NewestFirst { get; init; } = true;
}
