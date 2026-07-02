namespace GameTest.Domain.Entities
{
    public class PlayerWeapon
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public int WeaponId { get; private set; }
        public Weapon Weapon { get; private set; } = null!;

        private readonly List<PlayerWeaponProperty> _properties = [];
        public IReadOnlyCollection<PlayerWeaponProperty> Properties => _properties;

        private PlayerWeapon() { }

        public PlayerWeapon(int playerId, int weaponId)
        {
            PlayerId = playerId;
            WeaponId = weaponId;
        }

        public void UpPropertyLevel(int playerWeaponPropertyId)
        {
            var property = _properties.FirstOrDefault(p => p.Id == playerWeaponPropertyId);
            if (property == null)
                throw new KeyNotFoundException($"Property with id {playerWeaponPropertyId} was not found!");
            property.UpLevel();
        }
    }
}
 