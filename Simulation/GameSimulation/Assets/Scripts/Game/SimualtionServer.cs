using Assets.Scripts.Game;
using System.Threading;
using System.Threading.Tasks;

public class SimulationServer
{
    private readonly GameDataInitializer _gameDataInitializer;
    private readonly GameSessionInitializer _gameSessionInitializer;

    private GameSimulation _simulation;

    private bool _catalogLoaded;

    public SimulationServer(
        GameDataInitializer gameDataInitializer,
        GameSessionInitializer gameSessionInitializer)
    {
        _gameDataInitializer = gameDataInitializer;
        _gameSessionInitializer = gameSessionInitializer;
    }

    public async Task StartGameAsync(
        int playerUnitId,
        int arenaId,
        string token,
        CancellationToken ct = default)
    {
        if (!_catalogLoaded)
        {
            await _gameDataInitializer.InitializeAsync(
                token,
                ct);

            _catalogLoaded = true;
        }

        var session =
            await _gameSessionInitializer.InitializeAsync(
                playerUnitId,
                arenaId,
                token,
                ct);

        _simulation =
            new GameSimulation(
                session);
    }

    public void Tick(
        float deltaTime)
    {
        _simulation?.Tick(
            deltaTime);
    }
}
