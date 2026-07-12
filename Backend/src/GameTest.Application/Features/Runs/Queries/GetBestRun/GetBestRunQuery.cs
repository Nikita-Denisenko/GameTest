using GameTest.Application.Features.Runs.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Runs.Queries.GetBestRun
{
    public record GetBestRunQuery : IRequest<RunReadModel>
    {
        public int PlayerId { get; init; }
    }
}
