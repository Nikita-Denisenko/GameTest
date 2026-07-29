using System.Collections.Generic;

namespace Assets.Scripts.ValueObjects
{
    public class NextLevelWeaponInfo
    {
        public int NextLevel { get; private set; }
        public int? NextLevelPrice { get; private set; }

        public IReadOnlyCollection<NextLevelWeaponPropertyInfo> NextLevelPropertiesInfo;

        public NextLevelWeaponInfo(
            int nextLevel, 
            int? nextLevelPrice, 
            IReadOnlyCollection<NextLevelWeaponPropertyInfo> nextLevelWeaponPropertiesInfo)
        {
            NextLevel = nextLevel;
            NextLevelPrice = nextLevelPrice;
            NextLevelPropertiesInfo = nextLevelWeaponPropertiesInfo;
        }
    }
}
