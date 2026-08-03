using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class EnemyQuantityRange
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public EnemyQuantityRange(int min, int max)
        {
            if (min < 0 || max < 0)
                throw new InvalidValueObjectException(
                    "Enemy quantity range values must be non-negative.");

            if (min > max)
                throw new InvalidValueObjectException(
                    "Minimum enemy quantity cannot be greater than maximum enemy quantity.");

            Min = min;
            Max = max;
        }
    }
}
