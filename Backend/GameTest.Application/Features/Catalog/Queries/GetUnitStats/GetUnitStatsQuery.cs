using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetUnitStats
{
    public record GetUnitStatsQuery : IRequest<List<UnitStatReadModel>>;
}
