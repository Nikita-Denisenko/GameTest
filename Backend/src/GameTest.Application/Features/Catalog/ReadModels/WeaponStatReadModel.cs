using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record WeaponStatReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public WeaponStatType Type { get; init; }
    }
}
