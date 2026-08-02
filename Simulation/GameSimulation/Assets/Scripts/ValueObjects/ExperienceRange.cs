using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class ExperienceRange
    {
        public int Min { get; }
        public int Max { get; }

        public ExperienceRange(int min, int max)
        {
            if (min < 0 || max < 0)
                throw new InvalidValueObjectException(
                    "Experience range values must be non-negative.");

            if (min > max)
                throw new InvalidValueObjectException(
                    "Minimum experience cannot be greater than maximum.");

            Min = min;
            Max = max;
        }
    }
}
