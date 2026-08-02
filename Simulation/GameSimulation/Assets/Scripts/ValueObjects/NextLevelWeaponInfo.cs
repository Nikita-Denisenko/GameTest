using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelWeaponInfo
    {
        public int NextLevel { get; }
        public int? NextLevelPrice { get; }
        public IReadOnlyCollection<NextLevelWeaponPropertyInfo> NextLevelPropertiesInfo { get; }

        public NextLevelWeaponInfo(
            int nextLevel,
            int? nextLevelPrice,
            IReadOnlyCollection<NextLevelWeaponPropertyInfo> nextLevelPropertiesInfo)
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
