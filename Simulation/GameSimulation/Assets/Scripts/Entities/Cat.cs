using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Cat : Unit
    {
        public CatType Type { get; private set; }

        private readonly List<CatProperty> _properties 
            = new List<CatProperty>();
        public IReadOnlyCollection<CatProperty> Properties 
            => _properties;

        public Cat(
            int id,
            string name, 
            Vector2 position,
            IReadOnlyCollection<CatProperty> properties,
            CatType type
            ) : base(id, name, position, GetMaxHealth(properties))
        {
            Type = type;
            _properties.AddRange(properties);
        }

        private static float GetMaxHealth(IEnumerable<CatProperty> properties)
        {
            var property = properties
                .FirstOrDefault(p => p.StatType == CatStatType.MaxHealth);

            if (property == null)
                throw new InvalidCatStateException(
                    "Cat must have MaxHealth property");

            return property.Value;
        }

        public float GetPropertyValue(CatStatType statType)
        {
            var property = _properties
            .FirstOrDefault(p => p.StatType == statType);

            if (property == null)
                throw new InvalidCatStateException(
                    $"Cat does not have property with type {statType}");

            return property.Value;
        }

        protected override float GetMaxHealth()
        {
           return GetPropertyValue(CatStatType.MaxHealth);
        }
    } 
}
