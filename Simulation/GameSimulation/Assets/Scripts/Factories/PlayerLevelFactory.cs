using Assets.Scripts.GameData;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.ValueObjects;

namespace Assets.Scripts.Factories
{
    public class PlayerLevelFactory
    {
        public PlayerLevel Create(
            PlayerLevelData data)
        {
            return new PlayerLevel(
                data.Experience,
                data.Level);
        }
    }
}
