using GameTest.Domain.Enums;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerWeaponListReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public WeaponType Type { get; init; }
    }
}
