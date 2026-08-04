using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class PlayerLevel
    {
        public int Id { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }

        private PlayerLevel() { }

        public PlayerLevel(int id, int experience, int level)
        {
            if (id <= 0)
                throw new DomainException("Id must be a positive integer.");

            if (experience < 0)
                throw new DomainException("Experience must be a non-negative integer.");

            if (level <= 0)
                throw new DomainException("Level must be a positive integer.");

            Id = id;
            Experience = experience;
            Level = level;
        }
    }
}
