using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ValueObjects
{
    public class WeaponStaticProperty
    {
        public string Name { get; private set; }
        public int StatId { get; private set; }
        public WeaponStatType Type { get; private set; }
        public float Value { get; private set; }
        public int Level { get; private set; }

        public WeaponStaticProperty(
            string name, 
            int statId,
            WeaponStatType type, 
            float value,
            int level)
        {
            Name = name;
            StatId = statId;
            Type = type;
            Value = value;
            Level = level;
        }
    }
}
