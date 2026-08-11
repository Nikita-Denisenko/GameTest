using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetCats
{
    public record GetCatsQuery : IRequest<IReadOnlyCollection<CatReadModel>>;
}
