using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetWeapons
{
    public record GetWeaponsQuery : IRequest<IReadOnlyCollection<WeaponReadModel>>;
}
