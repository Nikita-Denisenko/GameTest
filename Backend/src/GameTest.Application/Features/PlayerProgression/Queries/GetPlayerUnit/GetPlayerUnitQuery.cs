using GameTest.Application.Features.PlayerProgression.ReadModels;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetUnit
{
    public record GetPlayerUnitQuery : IRequest<PlayerUnitReadModel>
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
