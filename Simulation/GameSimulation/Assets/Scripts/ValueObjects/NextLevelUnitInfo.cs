using System.Collections.Generic;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelUnitInfo
    {
        public int NextLevel { get; private set; }
        public int? NextLevelPrice { get; private set; }
        public IReadOnlyCollection<NextLevelUnitPropertyInfo> NextLevelPropertiesInfo { get; private set; }

        public NextLevelUnitInfo(
            int nextLevel,
            int? nextLevelPrice,
            IReadOnlyCollection<NextLevelUnitPropertyInfo> nextLevelPropertiesInfo)
        {
            NextLevel = nextLevel;
            NextLevelPrice = nextLevelPrice;
            NextLevelPropertiesInfo = nextLevelPropertiesInfo;
        }
    }
}
