using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record UnitReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public UnitType Type { get; init; }
        public int StartWeaponId { get; init; }
        public PassiveAbilityReadModel PassiveAbility { get; init; } = null!;
        public IReadOnlyCollection<UnitPropertyReadModel> Properties { get; init; } = [];
        public IReadOnlyCollection<TemporaryUpgradeLevelReadModel> TemporaryUpgradeLevels { get; init; } = [];
    }
}
