using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record EnemyQuantityRange
    {
        public int Min { get; init; }
        public int Max { get; init; }

        private EnemyQuantityRange()
        {
        }

        public EnemyQuantityRange(int min, int max)
        {
            if (min <= 0 || max <= 0)
                throw new DomainException("Min and Max must be positive.");
            if (min > max)
                throw new DomainException("Min cannot be greater than Max.");

            Min = min;
            Max = max;
        }
    }
}
