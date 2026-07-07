using GameTest.Application.Features.Runs.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Runs.Queries.GetRun
{
    public record GetRunQuery : IRequest<RunReadModel>
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
