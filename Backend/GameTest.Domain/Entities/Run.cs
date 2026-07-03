using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class Run
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public UnitType UnitType { get; private set; }
        public DateTime StartedAt { get; private set; }
        public int DurationSeconds { get; private set; }
        public int Kills { get; private set; }
        public int GoldEarned { get; private set; }
        public int LevelReached { get; private set; }

        private Run() { }

        public Run(
            int playerId,
            UnitType unitType, 
            DateTime startedAt, 
            int durationSeconds, 
            int kills, 
            int goldEarned, 
            int levelReached)
        {
            if (playerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(playerId), "Player ID cannot be zero or negative");

            if (!Enum.IsDefined(typeof(UnitType), unitType))
                throw new ArgumentException("Invalid UnitType", nameof(unitType));

            if (startedAt == default)
                throw new ArgumentException("StartedAt cannot be default", nameof(startedAt));

            if (durationSeconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(durationSeconds), "Duration must be a positive number");

            if (kills < 0)
                throw new ArgumentOutOfRangeException(nameof(kills), "Kills cannot be negative");

            if (goldEarned < 0)
                throw new ArgumentOutOfRangeException(nameof(goldEarned), "Gold earned cannot be negative");

            if (levelReached < 0)
                throw new ArgumentOutOfRangeException(nameof(levelReached), "Level reached cannot be negative");

            PlayerId = playerId;
            UnitType = unitType;
            StartedAt = startedAt;
            DurationSeconds = durationSeconds;
            Kills = kills;
            GoldEarned = goldEarned;
            LevelReached = levelReached;
        }
    }
}
