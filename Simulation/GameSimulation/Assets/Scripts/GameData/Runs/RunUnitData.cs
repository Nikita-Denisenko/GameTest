using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.GameData.Runs
{
    public class RunUnitData
    {
        public int PlayerUnitId { get; }
        public int UnitId { get; }
        public IReadOnlyCollection<RunUnitPropertyData> Properties { get; }


        public RunUnitData(
            int playerUnitId,
            int unitId,
            IReadOnlyCollection<RunUnitPropertyData> properties)
        {
            if (playerUnitId <= 0)
                throw new InvalidValueObjectException(
                    "Player unit id must be greater than zero.");

            if (unitId <= 0)
                throw new InvalidValueObjectException(
                    "Unit id must be greater than zero.");

            PlayerUnitId = playerUnitId;
            UnitId = unitId;

            Properties = properties
                ?? throw new InvalidValueObjectException(
                    "Unit properties cannot be null.");
        }
    }
}