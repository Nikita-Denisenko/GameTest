using GameTest.Application.Features.Runs.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Runs.Queries.GetRuns
{
    public record GetRunsQuery : IRequest<IReadOnlyCollection<RunReadModel>>
    {
        public int PlayerId { get; init; }
        public int Page { get; init; }
        public int Size { get; init; }
        public bool NewestFirst { get; init; }
    }
}
