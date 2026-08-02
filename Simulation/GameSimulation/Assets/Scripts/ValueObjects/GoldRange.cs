using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class GoldRange
    {
        public int Min { get; }
        public int Max { get; }

        public GoldRange(int min, int max)
        {
            if (min < 0 || max < 0)
                throw new InvalidValueObjectException(
                    "Gold range values must be non-negative.");

            if (min > max)
                throw new InvalidValueObjectException(
                    "Minimum gold cannot be greater than maximum gold.");

            Min = min;
            Max = max;
        }
    }
}
