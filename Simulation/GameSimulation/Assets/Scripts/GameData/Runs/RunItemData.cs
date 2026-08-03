using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.Runs
{
    public class RunItemData
    {
        public int PlayerItemId { get; }
        public int ItemId { get; }
        public float Bonus { get; }
        public int Level { get; }

        public RunItemData(
            int playerItemId,
            int itemId,
            float bonus,
            int level)
        {
            if (playerItemId <= 0)
                throw new InvalidValueObjectException(
                    "Player item id must be greater than zero.");

            if (itemId <= 0)
                throw new InvalidValueObjectException(
                    "Item id must be greater than zero.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Bonus cannot be negative.");

            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than zero.");

            PlayerItemId = playerItemId;
            ItemId = itemId;
            Bonus = bonus;
            Level = level;
        }
    }
}
