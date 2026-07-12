using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetEnemies
{
    public record GetEnemiesQuery : IRequest<IReadOnlyCollection<EnemyReadModel>>;
}
