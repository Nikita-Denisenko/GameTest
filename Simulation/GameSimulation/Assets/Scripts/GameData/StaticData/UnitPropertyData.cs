using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class UnitPropertyData
    {
        public int StatId { get; }
        public string StatName { get; }
        public IReadOnlyCollection<LevelProgressionData> Levels { get; }
        public IReadOnlyCollection<TemporaryLevelData> TemporaryLevels { get; }

        public UnitPropertyData(
            int statId,
            string statName,
            IReadOnlyCollection<LevelProgressionData> levels,
            IReadOnlyCollection<TemporaryLevelData> temporaryLevels)
        {
            if (statId <= 0)
                throw new InvalidUnitStateException("Stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(statName))
                throw new InvalidUnitStateException("Stat name cannot be empty.");

            StatId = statId;
            StatName = statName;
            Levels = levels ?? throw new InvalidUnitStateException("Levels cannot be null.");
            TemporaryLevels = temporaryLevels ?? throw new InvalidUnitStateException("Temporary levels cannot be null.");
        }
    }
}
