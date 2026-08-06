using GameTest.Api.Requests.Runs;
using GameTest.Application.Features.Runs.Commands.SaveRun;
using GameTest.Application.Features.Runs.Queries.GetBestRun;
using GameTest.Application.Features.Runs.Queries.GetRun;
using GameTest.Application.Features.Runs.Queries.GetRunPreparation;
using GameTest.Application.Features.Runs.Queries.GetRuns;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTest.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RunsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public RunsController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRuns(
            [FromQuery] GetRunsRequest request, 
            CancellationToken ct)
        {
            var query = new GetRunsQuery
            {
                PlayerId = _currentUserService.PlayerId,
                Page = request.Page,
                Size = request.Size,
                NewestFirst = request.NewestFirst
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("best")]
        public async Task<IActionResult> GetBestRun(CancellationToken ct)
        {
            var query = new GetBestRunQuery
            {
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRun(
            [FromRoute] int id, 
            CancellationToken ct)
        {
            var query = new GetRunQuery
            {
                Id = id,
                PlayerId = _currentUserService.PlayerId,
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpPost]
        public async Task<IActionResult> SaveRun(
            [FromBody] SaveRunRequest request, 
            CancellationToken ct)
        {
            var command = new SaveRunCommand
            {
                IdempotencyKey = request.IdempotencyKey,
                PlayerId = _currentUserService.PlayerId,
                UnitId = request.UnitId,
                StartedAt = request.StartedAt,
                DurationSeconds = request.DurationSeconds,
                Kills = request.Kills,
                GoldEarned = request.GoldEarned,
                LevelReached = request.LevelReached
            };

            var newRun = await _mediator.Send(command, ct);

            return CreatedAtAction(nameof(GetRun), new {id = newRun.RunId}, newRun);
        }

        [HttpGet("preparation")]
        public async Task<IActionResult> GetRunPreparation(
            [FromQuery] GetRunPreparationRequest request,
            CancellationToken ct)
        {
            var query = new GetRunPreparationQuery
            {
                PlayerId = _currentUserService.PlayerId,
                PlayerUnitId = request.PlayerUnitId,
                ArenaId = request.ArenaId,
            };

            return Ok(await _mediator.Send(query, ct));
        }
    }
}
