using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetCatStats
{
    public record GetCatStatsQuery : IRequest<IReadOnlyCollection<CatStatReadModel>>;
}
