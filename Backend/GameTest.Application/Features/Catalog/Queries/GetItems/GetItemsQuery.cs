using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetItems
{
    public record GetItemsQuery : IRequest<IReadOnlyCollection<ItemReadModel>>;
}
