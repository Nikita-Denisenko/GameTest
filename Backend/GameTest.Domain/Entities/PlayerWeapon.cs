namespace GameTest.Domain.Entities
{
    public class PlayerWeapon
    {
        public int Id { get; private set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int WeaponId { get; set; }
        public Weapon Weapon { get; private set; } = null!;

        private PlayerWeapon() { }

        public PlayerWeapon(int playerId, int weaponId)
        {
            PlayerId = playerId;
            WeaponId = weaponId;
        }
    }
}
 