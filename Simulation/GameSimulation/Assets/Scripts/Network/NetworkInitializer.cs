using Assets.Scripts.Network.Contracts.Requests;
using Assets.Scripts.Network.Handlers;
using Mirror;
using VContainer.Unity;

namespace Assets.Scripts.Network
{
    public class NetworkInitializer : IStartable
    {
        private readonly StartGameRequestHandler _startGameRequestHandler;

        public NetworkInitializer(
            StartGameRequestHandler startGameRequestHandler)
        {
            _startGameRequestHandler = startGameRequestHandler;
        }

        public void Start()
        {
            NetworkServer.RegisterHandler<StartGameRequest>(
                async (_, request) =>
                {
                    await _startGameRequestHandler.HandleAsync(request);
                });
        }
    }
}

