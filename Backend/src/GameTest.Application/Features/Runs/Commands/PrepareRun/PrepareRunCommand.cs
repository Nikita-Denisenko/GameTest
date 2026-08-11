using GameTest.Application.Features.Runs.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Runs.Commands.PrepareRun
{
    public record PrepareRunCommand : IRequest<RunPreparationReadModel>
    {
        public int PlayerId { get; init; }
        public int PlayerUnitId { get; init; }
        public int ArenaId { get; init; }
        public int? CatId { get; init; }
    }
}
