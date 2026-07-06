using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetWeaponStats
{
    public record GetWeaponStatsQuery : IRequest<List<WeaponStatReadModel>>;
}
