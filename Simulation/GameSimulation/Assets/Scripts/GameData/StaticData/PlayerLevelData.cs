using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.StaticData
{
    public class PlayerLevelData
    {
        public int Id { get; }
        public int Experience { get; }
        public int Level { get; }

        public PlayerLevelData(
            int id,
            int experience,
            int level)
        {
            if (id <= 0)
                throw new InvalidValueObjectException(
                    "Id must be a positive integer.");

            if (experience < 0)
                throw new InvalidValueObjectException(
                    "Experience cannot be negative.");

            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than zero.");

            Id = id;
            Experience = experience;
            Level = level;
        }
    }
}
