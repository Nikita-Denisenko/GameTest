using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class WeaponPropertyData
    {
        public int StatId { get; }
        public string StatName { get; }
        public IReadOnlyCollection<LevelProgressionData> Levels { get; }
        public IReadOnlyCollection<TemporaryLevelData> TemporaryLevels { get; }

        public WeaponPropertyData(
            int statId,
            string statName,
            IReadOnlyCollection<LevelProgressionData> levels,
            IReadOnlyCollection<TemporaryLevelData> temporaryLevels)
        {
            if (statId <= 0)
                throw new InvalidWeaponStateException("Stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(statName))
                throw new InvalidWeaponStateException("Stat name cannot be empty.");

            StatId = statId;
            StatName = statName;
            Levels = levels ?? throw new InvalidWeaponStateException("Levels cannot be null.");
            TemporaryLevels = temporaryLevels ?? throw new InvalidWeaponStateException("Temporary levels cannot be null.");
        }
    }
}
