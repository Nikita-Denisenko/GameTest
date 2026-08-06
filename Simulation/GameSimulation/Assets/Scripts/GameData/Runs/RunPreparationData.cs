using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.GameData.Runs
{
    public class RunPreparationData
    {
        public int ArenaId { get; }
        public int PlayerId { get; }
        public RunUnitData Unit { get; }
        public IReadOnlyCollection<RunWeaponData> Weapons { get; }
        public IReadOnlyCollection<RunItemData> Items { get; }


        public RunPreparationData(
            int arenaId,
            int playerId,
            RunUnitData unit,
            IReadOnlyCollection<RunWeaponData> weapons,
            IReadOnlyCollection<RunItemData> items)
        {
            if (arenaId <= 0)
                throw new InvalidValueObjectException(
                    "Arena id must be greater than zero.");

            if (playerId <= 0)
                throw new InvalidValueObjectException(
                    "Player id must be greater than zero.");

            ArenaId = arenaId;

            Unit = unit
                ?? throw new InvalidValueObjectException(
                    "Unit data cannot be null.");

            Weapons = weapons
                ?? throw new InvalidValueObjectException(
                    "Weapons cannot be null.");

            Items = items
                ?? throw new InvalidValueObjectException(
                    "Items cannot be null.");

            PlayerId = playerId;
        }
    }
}
