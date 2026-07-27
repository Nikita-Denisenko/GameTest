using Assets.Scripts.Enums;

namespace Assets.Scripts.ValueObjects
{
    public class EnemyStaticProperty
    {
        public string Name { get; private set; }
        public int StatId { get; private set; }
        public EnemyStatType Type { get; private set; }
        public float Value { get; private set; }

        public EnemyStaticProperty(
            string name,
            int statId,
            EnemyStatType type,
            float value)
        {
            Name = name;
            StatId = statId;
            Type = type; 
            Value = value;
        }
    }
}
