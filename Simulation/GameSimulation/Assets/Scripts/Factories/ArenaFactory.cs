using Assets.Scripts.Entities;
using Assets.Scripts.GameData.StaticData;

namespace Assets.Scripts.Factories
{
    public class ArenaFactory
    {
        public Arena Create(ArenaData arenaData)
        {
            return new Arena(
                arenaData.Id,
                arenaData.Name,
                arenaData.Width,
                arenaData.Height);
        }
    }
}
