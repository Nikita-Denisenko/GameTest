using Assets.Scripts.Game;
using Assets.Scripts.Network.Contracts.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Network.Handlers
{
	public class StartGameRequestHandler
	{
		private readonly SimulationServer _simulationServer;

		public StartGameRequestHandler(
			SimulationServer simulationServer)
		{
			_simulationServer = simulationServer;
		}

		public Task HandleAsync(
			StartGameRequest request,
			CancellationToken ct = default)
		{
			return _simulationServer.StartGameAsync(
				request.PlayerUnitId,
				request.ArenaId,
                request.CatId,
                request.Token,
                ct);
		}
	}
}
