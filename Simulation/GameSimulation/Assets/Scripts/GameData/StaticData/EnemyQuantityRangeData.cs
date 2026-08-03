using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class EnemyQuantityRangeData
    {
        public int Min { get; }
        public int Max { get; }

        public EnemyQuantityRangeData(
            int min,
            int max)
        {
            if (min <= 0)
                throw new InvalidValueObjectException("Minimum value must be greater than zero.");

            if (max < min)
                throw new InvalidValueObjectException("Maximum value cannot be less than minimum value.");

            Min = min;
            Max = max;
        }
    }
}
