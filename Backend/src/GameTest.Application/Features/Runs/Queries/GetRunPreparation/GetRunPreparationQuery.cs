using GameTest.Application.Features.Runs.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Runs.Queries.GetRunPreparation
{
    public record GetRunPreparationQuery : IRequest<RunPreparationReadModel>
    {
        public int PlayerId { get; init; }
        public int PlayerUnitId { get; init; }
        public int ArenaId { get; init; }
    }
}
