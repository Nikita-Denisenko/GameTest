using GameTest.Application.Features.Catalog.Queries.GetEnemies;
using GameTest.Application.Features.Catalog.Queries.GetEnemyStats;
using GameTest.Application.Features.Catalog.Queries.GetItems;
using GameTest.Application.Features.Catalog.Queries.GetUnits;
using GameTest.Application.Features.Catalog.Queries.GetUnitStats;
using GameTest.Application.Features.Catalog.Queries.GetWavesInfo;
using GameTest.Application.Features.Catalog.Queries.GetWeapons;
using GameTest.Application.Features.Catalog.Queries.GetWeaponStats;
using GameTest.Application.Features.Catalog.Queries.GetCatalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameTest.Application.Features.Catalog.Queries.GetPlayerLevels;
using GameTest.Application.Features.Catalog.Queries.GetArenas;
using GameTest.Application.Features.Catalog.Queries.GetCats;

namespace GameTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("enemies")]
        public async Task<IActionResult> GetEnemies(CancellationToken ct)
            => Ok(await _mediator.Send(new GetEnemiesQuery(), ct));

        [HttpGet("enemy-stats")]
        public async Task<IActionResult> GetEnemyStats(CancellationToken ct)
            => Ok(await _mediator.Send(new GetEnemyStatsQuery(), ct));

        [HttpGet("items")]
        public async Task<IActionResult> GetItems(CancellationToken ct)
            => Ok(await _mediator.Send(new GetItemsQuery(), ct));

        [HttpGet("units")]
        public async Task<IActionResult> GetUnits(CancellationToken ct)
            => Ok(await _mediator.Send(new GetUnitsQuery(), ct));

        [HttpGet("unit-stats")]
        public async Task<IActionResult> GetUnitStats(CancellationToken ct)
            => Ok(await _mediator.Send(new GetUnitStatsQuery(), ct));

        [HttpGet("weapons")]
        public async Task<IActionResult> GetWeapons(CancellationToken ct)
            => Ok(await _mediator.Send(new GetWeaponsQuery(), ct));

        [HttpGet("weapon-stats")]
        public async Task<IActionResult> GetWeaponStats(CancellationToken ct)
            => Ok(await _mediator.Send(new GetWeaponStatsQuery(), ct));

        [HttpGet("waves")]
        public async Task<IActionResult> GetWaves(CancellationToken ct)
            => Ok(await _mediator.Send(new GetWavesQuery(), ct));

        [HttpGet("player-levels")]
        public async Task<IActionResult> GetPlayerLevels(CancellationToken ct)
            => Ok(await _mediator.Send(new GetPlayerLevelsQuery(), ct));

        [HttpGet("arenas")]
        public async Task<IActionResult> GetArenas(CancellationToken ct)
            => Ok(await _mediator.Send(new GetArenasQuery(), ct));

        [HttpGet("cats")]
        public async Task<IActionResult> GetCats(CancellationToken ct)
            => Ok(await _mediator.Send(new GetCatsQuery(), ct));

        [HttpGet("cat-stats")]
        public async Task<IActionResult> GetCatStats(CancellationToken ct)
            => Ok(await _mediator.Send(new GetCatsQuery(), ct));

        [HttpGet]
        public async Task<IActionResult> GetCatalog(CancellationToken ct)
            => Ok(await _mediator.Send(new GetCatalogQuery(), ct));
    }
}
