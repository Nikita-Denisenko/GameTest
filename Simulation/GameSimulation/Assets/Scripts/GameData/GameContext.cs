using Assets.Scripts.Exceptions;
using Assets.Scripts.GameData;

namespace Assets.Scripts.Game
{
    public class GameContext
    {
        public Catalog Catalog { get; private set; }


        public void Initialize(
            Catalog catalog)
        {
            if (catalog == null)
                throw new InvalidGameSessionStateException(
                    "Catalog cannot be null.");

            Catalog = catalog;
        }
    }
}