using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetEnemyStats
{
    public record GetEnemyStatsQuery : IRequest<List<EnemyStatReadModel>>;
}
