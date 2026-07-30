
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
            NextLevel = nextLevel;
            NextLevelBonus = nextLevelBonus;
            NextLevelPrice = nextLevelPrice;
        }
    }
}
