using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class ExperienceRangeData
    {
        public int Min { get; }
        public int Max { get; }

        public ExperienceRangeData(
            int min,
            int max)
        {
            if (min <= 0)
                throw new InvalidValueObjectException("Minimum experience must be greater than zero.");

            if (max < min)
                throw new InvalidValueObjectException("Maximum experience cannot be less than minimum experience.");

            Min = min;
            Max = max;
        }
    }
}