using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record PassiveAbilityReadModel
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public float Bonus { get; init; }
        public PassiveAbilityType Type { get; init; }
    }
}
