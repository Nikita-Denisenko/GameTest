using GameTest.Domain.Enums;

namespace GameTest.Application.Features.Catalog.ReadModels
{
    public record EnemyReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public EnemyType EnemyType { get; init; }
        public EnemyAttackType AttackType { get; init; }
        public IReadOnlyCollection<EnemyPropertyReadModel> Properties { get; init; } = [];
        public EnemyMovementType MovementType { get; init; }
        public EnemyLootReadModel Loot { get; init; } = null!;
    }
}
