using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerWeaponReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public WeaponType Type { get; init; }
        public IReadOnlyCollection<PlayerWeaponPropertyReadModel> Properties { get; init; } = [];
    }
}
