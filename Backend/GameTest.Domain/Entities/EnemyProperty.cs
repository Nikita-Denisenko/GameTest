namespace GameTest.Domain.Entities
{
    public class EnemyProperty
    {
        public int Id { get; private set; }
        public int EnemyId { get; private set; }
        public Enemy Enemy { get; private set; } = null!;
        public int EnemyStatId { get; private set; }
        public EnemyStat EnemyStat { get; private set; } = null!;
        public double Value { get; private set; }

        private EnemyProperty() { }

        public EnemyProperty(EnemyStat enemyStat, double value)
        {
            EnemyStatId = enemyStat.Id;
            EnemyStat = enemyStat;
            Value = value;
        }
    }
}
