using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelItemInfo
    {
        public int NextLevel { get; }
        public float? NextLevelBonus { get; }
        public int? NextLevelPrice { get; }

        public NextLevelItemInfo(
            int nextLevel,
            float nextLevelBonus,
            int nextLevelPrice)
        {
            if (nextLevel <= 0)
                throw new InvalidValueObjectException(
                    "Next level must be greater than 0.");

            if (nextLevelBonus < 0)
                throw new InvalidValueObjectException(
                    "Next level bonus cannot be negative.");

            if (nextLevelPrice < 0)
                throw new InvalidValueObjectException(
                    "Next level price cannot be negative.");

            NextLevel = nextLevel;
            NextLevelBonus = nextLevelBonus;
            NextLevelPrice = nextLevelPrice;
        }
    }
}
