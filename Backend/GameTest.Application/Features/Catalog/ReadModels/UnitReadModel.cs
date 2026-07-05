using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record UnitReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public UnitType Type { get; init; }
        public int StartWeaponId { get; init; }
        public string StartWeaponName { get; init; } = string.Empty;
        public PassiveAbility PassiveAbility { get; init; } = null!;
        public double Bonus { get; init; }
        public PassiveAbilityType PassiveAbilityType { get; init; }
        public List<UnitPropertyReadModel> Properties { get; init; } = [];
    }
}
