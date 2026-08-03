using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class GoldRangeData
    {
        public int Min { get; }
        public int Max { get; }

        public GoldRangeData(
            int min,
            int max)
        {
            if (min <= 0)
                throw new InvalidValueObjectException("Minimum gold must be greater than zero.");

            if (max < min)
                throw new InvalidValueObjectException("Maximum gold cannot be less than minimum gold.");

            Min = min;
            Max = max;
        }
    }
}