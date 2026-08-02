using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class PlayerLevel
    {
        public int Experience { get; }
        public int Level { get; }

        public PlayerLevel(
            int experience,
            int level)
        {
            if (experience < 0)
                throw new InvalidValueObjectException(
                    "Experience cannot be negative.");

            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than 0.");

            Experience = experience;
            Level = level;
        }
    }
}
