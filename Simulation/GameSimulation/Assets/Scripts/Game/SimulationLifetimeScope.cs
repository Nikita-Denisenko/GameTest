using Assets.Scripts.Api;
using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.Factories;
using Assets.Scripts.GameData;
using Assets.Scripts.Network;
using Assets.Scripts.Network.Handlers;
using Assets.Scripts.Services;
using System;
using System.Net.Http;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Game
{
    public class SimulationLifetimeScope : LifetimeScope
    {
        protected override void Configure(
            IContainerBuilder builder)
        {
            builder.Register<GameContext>(
                Lifetime.Singleton);

            builder.Register<CatalogBuilder>(
                Lifetime.Singleton);

            builder.Register<GameDataInitializer>(
                Lifetime.Singleton);

            builder.Register<GameSessionInitializer>(
                Lifetime.Singleton);

            builder.Register<GameSessionFactory>(
                Lifetime.Singleton);

            builder.Register<ArenaFactory>(
               Lifetime.Singleton);

            builder.Register<EnemyFactory>(
              Lifetime.Singleton);

            builder.Register<ItemFactory>(
                Lifetime.Singleton);

            builder.Register<MovementStrategyFactory>(
                Lifetime.Singleton);

            builder.Register<PlayerFactory>(
                Lifetime.Singleton);

            builder.Register<PlayerLevelFactory>(
                Lifetime.Singleton);

            builder.Register<PlayerUnitFactory>(
                Lifetime.Singleton);

            builder.Register<WaveFactory>(
                Lifetime.Singleton);

            builder.Register<WeaponFactory>(
                Lifetime.Singleton);

            builder.Register<MovementService>(
                Lifetime.Singleton);

            builder.Register<SpawnPositionService>(
                Lifetime.Singleton);

            builder.Register<SpawnService>(
                Lifetime.Singleton);

            builder.Register<WaveService>(
                Lifetime.Singleton);

            builder.Register<ICatalogApiClient, CatalogApiClient>(
                Lifetime.Singleton);

            builder.Register<IRunPreparationApiClient, RunPreparationApiClient>(
                Lifetime.Singleton);

            builder.Register<SimulationServer>(
                Lifetime.Singleton);

            builder.RegisterEntryPoint<NetworkInitializer>();

            builder.Register<StartGameRequestHandler>(
                Lifetime.Singleton);

            builder.Register<CatFactory>(
                Lifetime.Singleton);

            builder.Register(
                _ => new HttpClient
            {
                BaseAddress =
                new Uri(
                "https://localhost:5001/")
            },
                Lifetime.Singleton);
        }
    }
}
