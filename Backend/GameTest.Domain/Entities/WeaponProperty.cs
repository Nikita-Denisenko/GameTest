using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class WeaponProperty
    {
        public int Id { get; private set; }
        public int WeaponId { get; private set; }
        public Weapon Weapon { get; private set; } = null!;
        public int StatId { get; private set; }
        public WeaponStat Stat { get; private set; } = null!;
        public double DefaultValue { get; private set; }
        public IReadOnlyCollection<WeaponPropertyLevel> Levels { get; private set; } = [];

        private WeaponProperty() { }

        public WeaponProperty
        (
            int weaponId, 
            int statId, 
            IReadOnlyCollection<WeaponPropertyLevel> levels, 
            double defaultValue = 0
        )
        {
            WeaponId = weaponId;
            StatId = statId;
            DefaultValue = defaultValue;
            Levels = levels;
        }

        public void UpdateDefaultValue(double newValue)
        {
            DefaultValue = newValue;
        }
    }
}