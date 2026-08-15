using Mirror;

namespace Assets.Scripts.Network.Contracts.Requests
{
    public struct StartGameRequest : NetworkMessage
    {
        public int PlayerUnitId;
        public int ArenaId;
        public int? CatId;
        public string Token;
    }
}
