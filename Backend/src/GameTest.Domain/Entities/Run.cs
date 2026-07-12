using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class Run
    {
        public int Id { get; private set; }
        public Guid IdempotencyKey { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public int UnitId { get; private set; }
        public Unit Unit { get; private set; } = null!;
        public DateTime StartedAt { get; private set; }
        public int DurationSeconds { get; private set; }
        public int Kills { get; private set; }
        public int GoldEarned { get; private set; }
        public int LevelReached { get; private set; }

        private Run() { }

        public Run(
            Guid idempotencyKey,
            int playerId,
            int unitId, 
            DateTime startedAt, 
            int durationSeconds, 
            int kills, 
            int goldEarned, 
            int levelReached)
        {
            if (playerId <= 0)
                throw new DomainException("Player ID cannot be zero or negative");

            if (unitId <= 0)
                throw new DomainException("Unit ID cannot be zero or negative");

            if (startedAt == default)
                throw new DomainException("StartedAt cannot be default");

            if (durationSeconds <= 0)
                throw new DomainException("Duration must be a positive number");

            if (kills < 0)
                throw new DomainException("Kills cannot be negative");

            if (goldEarned < 0)
                throw new DomainException("Gold earned cannot be negative");

            if (levelReached < 0)
                throw new DomainException("Level reached cannot be negative");

            IdempotencyKey = idempotencyKey;
            PlayerId = playerId;
            UnitId = unitId;
            StartedAt = startedAt;
            DurationSeconds = durationSeconds;
            Kills = kills;
            GoldEarned = goldEarned;
            LevelReached = levelReached;
        }
    }
}
