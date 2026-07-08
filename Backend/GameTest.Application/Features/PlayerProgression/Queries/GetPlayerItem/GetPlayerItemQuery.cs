using GameTest.Application.Features.PlayerProgression.ReadModels;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetItem
{
    public record GetPlayerItemQuery : IRequest<PlayerItemReadModel>
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
