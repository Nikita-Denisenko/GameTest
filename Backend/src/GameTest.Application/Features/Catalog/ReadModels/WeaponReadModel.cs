using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record WeaponReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public WeaponType Type { get; init; }
        public IReadOnlyCollection<WeaponPropertyReadModel> Properties { get; init; } = [];
        public IReadOnlyCollection<TemporaryUpgradeLevelReadModel> TemporaryUpgradeLevels { get; init; } = [];
    }
}
