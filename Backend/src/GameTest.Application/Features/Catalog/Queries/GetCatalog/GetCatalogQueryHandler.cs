using GameTest.Application.Features.Catalog.Queries.GetArenas;
using GameTest.Application.Features.Catalog.Queries.GetEnemies;
using GameTest.Application.Features.Catalog.Queries.GetEnemyStats;
using GameTest.Application.Features.Catalog.Queries.GetItems;
using GameTest.Application.Features.Catalog.Queries.GetPlayerLevels;
using GameTest.Application.Features.Catalog.Queries.GetUnits;
using GameTest.Application.Features.Catalog.Queries.GetUnitStats;
using GameTest.Application.Features.Catalog.Queries.GetWavesInfo;
using GameTest.Application.Features.Catalog.Queries.GetWeapons;
using GameTest.Application.Features.Catalog.Queries.GetWeaponStats;
using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetCatalog
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, CatalogReadModel>
    {
        private readonly IMediator _mediator;

        public GetCatalogQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CatalogReadModel> Handle(
            GetCatalogQuery query,
            CancellationToken ct)
        {
            var enemiesTask = _mediator.Send(new GetEnemiesQuery(), ct);
            var enemyStatsTask = _mediator.Send(new GetEnemyStatsQuery(), ct);
            var itemsTask = _mediator.Send(new GetItemsQuery(), ct);
            var unitsTask = _mediator.Send(new GetUnitsQuery(), ct);
            var unitStatsTask = _mediator.Send(new GetUnitStatsQuery(), ct);
            var weaponsTask = _mediator.Send(new GetWeaponsQuery(), ct);
            var weaponStatsTask = _mediator.Send(new GetWeaponStatsQuery(), ct);
            var wavesTask = _mediator.Send(new GetWavesQuery(), ct);
            var playerLevelsTask = _mediator.Send(new GetPlayerLevelsQuery(), ct);
            var arenasTask = _mediator.Send(new GetArenasQuery(), ct);

            await Task.WhenAll(
                enemiesTask,
                enemyStatsTask,
                itemsTask,
                unitsTask,
                unitStatsTask,
                weaponsTask,
                weaponStatsTask,
                wavesTask,
                playerLevelsTask,
                arenasTask);

            return new CatalogReadModel
            {
                Enemies = await enemiesTask,
                EnemyStats = await enemyStatsTask,

                Items = await itemsTask,

                Units = await unitsTask,
                UnitStats = await unitStatsTask,

                Weapons = await weaponsTask,
                WeaponStats = await weaponStatsTask,

                Waves = await wavesTask,

                PlayerLevels = await playerLevelsTask,

                Arenas = await arenasTask
            };
        }
    }
}
