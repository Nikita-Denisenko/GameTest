using Assets.Scripts.Api;
using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.Factories;
using Assets.Scripts.GameData;
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

            builder.Register<ICatalogApiClient, CatalogApiClient>(
                Lifetime.Singleton);

            builder.Register<IRunPreparationApiClient, RunPreparationApiClient>(
                Lifetime.Singleton);

            builder.Register<SimulationServer>(
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
