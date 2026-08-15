using Assets.Scripts.Exceptions.Domain;

namespace Assets.Scripts.GameData.StaticData
{
    public class CatPropertyData
    {
        public int StatId { get; }
        public string StatName { get; } = string.Empty;
        public float Value { get; }

        public CatPropertyData(
            int statId,
            string statName,
            float value) 
        {
            if (statId <= 0)
                throw new InvalidCatStateException("CatProperty StatId must be positive.");

            if (string.IsNullOrWhiteSpace(statName))
                throw new InvalidCatStateException("CatProperty statName cannot be empty.");

            if (value < 0)
                throw new InvalidCatStateException("CatProperty value cannot be negative.");

            StatId = statId;
            StatName = statName;
            Value = value;
            Value = value;
        }
    }
}
