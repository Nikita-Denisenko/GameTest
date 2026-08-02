using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelUnitInfo
    {
        public int NextLevel { get; }
        public int? NextLevelPrice { get; }
        public IReadOnlyCollection<NextLevelUnitPropertyInfo> NextLevelPropertiesInfo { get; }

        public NextLevelUnitInfo(
            int nextLevel,
            int? nextLevelPrice,
            IReadOnlyCollection<NextLevelUnitPropertyInfo> nextLevelPropertiesInfo)
        {
            if (nextLevel <= 0)
                throw new InvalidValueObjectException(
                    "Next level must be greater than 0.");

            if (nextLevelPrice < 0)
                throw new InvalidValueObjectException(
                    "Next level price cannot be negative.");

            if (nextLevelPropertiesInfo == null)
                throw new InvalidValueObjectException(
                    "Next level properties cannot be null.");

            NextLevel = nextLevel;
            NextLevelPrice = nextLevelPrice;
            NextLevelPropertiesInfo = nextLevelPropertiesInfo;
        }
    }
}
