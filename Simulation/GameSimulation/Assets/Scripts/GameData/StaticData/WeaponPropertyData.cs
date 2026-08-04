using Assets.Scripts.Exceptions;
using Assets.Scripts.GameData.StaticData;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class WeaponPropertyData
    {
        public int StatId { get; }
        public string StatName { get; }
        public IReadOnlyCollection<TemporaryLevelData> TemporaryLevels { get; }

        public WeaponPropertyData(
            int statId,
            string statName,
            IReadOnlyCollection<TemporaryLevelData> temporaryLevels)
        {
            if (statId <= 0)
                throw new InvalidWeaponStateException("Stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(statName))
                throw new InvalidWeaponStateException("Stat name cannot be empty.");

            StatId = statId;
            StatName = statName;
            TemporaryLevels = temporaryLevels ?? throw new InvalidWeaponStateException("Temporary levels cannot be null.");
        }
    }
}
