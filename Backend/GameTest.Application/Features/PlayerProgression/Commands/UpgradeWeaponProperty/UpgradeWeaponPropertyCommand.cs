using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeWeaponProperty
{
    public record UpgradeWeaponPropertyCommand : IRequest
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
