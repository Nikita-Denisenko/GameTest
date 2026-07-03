using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class Run
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public UnitType UnitType { get; private set; }
        public DateTime StartTime { get; private set; }
        public int DurationSeconds { get; private set; }
        public int Kills { get; private set; }
        public int GoldEarned { get; private set; }
        public int LevelReached { get; private set; }

        private Run() { }

        public Run(
            int playerId,
            UnitType unitType, 
            DateTime startTime, 
            int durationSeconds, 
            int kills, 
            int goldEarned, 
            int levelReached)
        {
            PlayerId = playerId;
            UnitType = unitType;
            StartTime = startTime;
            DurationSeconds = durationSeconds;
            Kills = kills;
            GoldEarned = goldEarned;
            LevelReached = levelReached;
        }
    }
}
