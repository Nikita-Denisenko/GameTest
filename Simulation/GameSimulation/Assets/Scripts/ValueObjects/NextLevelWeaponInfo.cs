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
            NextLevel = nextLevel;
            NextLevelPrice = nextLevelPrice;
            NextLevelPropertiesInfo = nextLevelPropertiesInfo;
        }
    }
}
