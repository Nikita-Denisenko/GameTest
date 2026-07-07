using GameTest.Application.Features.PlayerProgression.ReadModels;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetWeapon
{
    public record GetPlayerWeaponQuery : IRequest<PlayerWeaponReadModel>
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
