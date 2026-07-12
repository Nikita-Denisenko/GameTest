using GameTest.Api.Requests.PlayerProgression;
using GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem;
using GameTest.Application.Features.PlayerProgression.Commands.UpgradeUnitProperty;
using GameTest.Application.Features.PlayerProgression.Commands.UpgradeWeaponProperty;
using GameTest.Application.Features.PlayerProgression.Queries.GetItem;
using GameTest.Application.Features.PlayerProgression.Queries.GetItems;
using GameTest.Application.Features.PlayerProgression.Queries.GetUnit;
using GameTest.Application.Features.PlayerProgression.Queries.GetUnits;
using GameTest.Application.Features.PlayerProgression.Queries.GetWeapon;
using GameTest.Application.Features.PlayerProgression.Queries.GetWeapons;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTest.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerProgressionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public PlayerProgressionController
        (
            IMediator mediator, 
            ICurrentUserService currentUserService
        )
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpGet("player-items")]
        public async Task<IActionResult> GetPlayerItems
        (
            [FromQuery] GetPlayerItemsRequest request,
            CancellationToken ct
        )
        {
            var query = new GetPlayerItemsQuery
            {
                PlayerId = _currentUserService.PlayerId,
                Page = request.Page,
                Size = request.Size,
                Type = request.Type,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("player-units")]
        public async Task<IActionResult> GetPlayerUnits
        (
            [FromQuery] GetPlayerUnitsRequest request,
            CancellationToken ct
        )
        {
            var query = new GetPlayerUnitsQuery
            {
                PlayerId = _currentUserService.PlayerId,
                Page = request.Page,
                Size = request.Size,
                Type = request.Type,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("player-weapons")]
        public async Task<IActionResult> GetPlayerWeapons
        (
           [FromQuery] GetPlayerWeaponsRequest request,
           CancellationToken ct
        )
        {
            var query = new GetPlayerWeaponsQuery
            {
                PlayerId = _currentUserService.PlayerId,
                Page = request.Page,
                Size = request.Size,
                Type = request.Type,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("player-items/{id:int}")]
        public async Task<IActionResult> GetPlayerItem
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var query = new GetPlayerItemQuery
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("player-units/{id:int}")]
        public async Task<IActionResult> GetPlayerUnit
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var query = new GetPlayerUnitQuery
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("player-weapons/{id:int}")]
        public async Task<IActionResult> GetPlayerWeapon
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var query = new GetPlayerWeaponQuery
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpPatch("player-items/{id:int}/upgrade")]
        public async Task<IActionResult> UpgradeItem
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var command = new UpgradeItemCommand
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(command, ct));
        }

        [HttpPatch("player-unit-properties/{id:int}/upgrade")]
        public async Task<IActionResult> UpgradeUnitProperty
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var command = new UpgradeUnitPropertyCommand
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(command, ct));
        }

        [HttpPatch("player-weapon-properties/{id:int}/upgrade")]
        public async Task<IActionResult> UpgradeWeaponProperty
        (
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var command = new UpgradeWeaponPropertyCommand
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(command, ct));
        }
    }
}
