using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData
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