using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Domain.Enums;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetItems
{
    public record GetPlayerItemsQuery : IRequest<IReadOnlyCollection<PlayerItemListReadModel>>
    {
        public int PlayerId { get; init; }
        public int Page { get; init; }
        public int Size { get; init; }
        public ItemType? Type { get; init; } 
    }
}
