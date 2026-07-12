using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Domain.Enums;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetWeapons
{
    public record GetPlayerWeaponsQuery : IRequest<IReadOnlyCollection<PlayerWeaponListReadModel>>
    {
        public int PlayerId { get; init; }
        public WeaponType? Type { get; init; }
        public int Page { get; init; }
        public int Size { get; init; }
    }
}
