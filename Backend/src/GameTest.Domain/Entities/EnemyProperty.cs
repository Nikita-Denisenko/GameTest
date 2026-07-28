using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class EnemyProperty
    {
        public int Id { get; private set; }
        public int EnemyId { get; private set; }
        public Enemy Enemy { get; private set; } = null!;
        public int StatId { get; private set; }
        public EnemyStat Stat { get; private set; } = null!;
        public float Value { get; private set; }

        private EnemyProperty() { }

        public EnemyProperty(EnemyStat stat, float value)
        {
            if (value < 0)
                throw new DomainException("Value must be a non-negative number");

            StatId = stat.Id;
            Stat = stat;
            Value = value;
        }
    }
}
