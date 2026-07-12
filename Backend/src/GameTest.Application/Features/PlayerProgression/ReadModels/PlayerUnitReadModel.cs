using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerUnitReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public UnitType Type { get; init; }
        public IReadOnlyCollection<PlayerUnitPropertyReadModel> Properties { get; init; } = [];
        public PassiveAbilityReadModel PassiveAbility { get; init; } = null!;
        public int StartWeaponId { get; init; }
        public string StartWeaponName { get; init; } = null!;
    }
}
