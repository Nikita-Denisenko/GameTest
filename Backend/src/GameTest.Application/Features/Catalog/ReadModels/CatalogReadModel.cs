namespace GameTest.Application.Features.Catalog.ReadModels
{
    public class CatalogReadModel
    {
        public IReadOnlyCollection<EnemyReadModel> Enemies { get; init; } = [];
        public IReadOnlyCollection<EnemyStatReadModel> EnemyStats { get; init; } = [];

        public IReadOnlyCollection<ItemReadModel> Items { get; init; } = [];

        public IReadOnlyCollection<UnitReadModel> Units { get; init; } = [];
        public IReadOnlyCollection<UnitStatReadModel> UnitStats { get; init; } = [];

        public IReadOnlyCollection<WeaponReadModel> Weapons { get; init; } = [];
        public IReadOnlyCollection<WeaponStatReadModel> WeaponStats { get; init; } = [];

        public IReadOnlyCollection<WaveReadModel> Waves { get; init; } = [];
    }
}
