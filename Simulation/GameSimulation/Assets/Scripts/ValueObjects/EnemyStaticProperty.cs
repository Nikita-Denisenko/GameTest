using Assets.Scripts.Enums;

namespace Assets.Scripts.ValueObjects
{
    public class EnemyStaticProperty
    {
        public string Name { get; private set; }
        public int StatId { get; private set; }
        public EnemyStatType StatType { get; private set; }
        public float Value { get; private set; }

        public EnemyStaticProperty(
            string name,
            int statId,
            EnemyStatType statType,
            float value)
        {
            Name = name;
            StatId = statId;
            StatType = statType; 
            Value = value;
        }
    }
}
