using GameTest.Api.Requests.PlayerProfile;
using GameTest.Application.Features.PlayerProfile.Commands.ChangeNickname;
using GameTest.Application.Features.PlayerProfile.Queries.GetProfile;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTest.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public PlayerProfileController(
            IMediator mediator,
            ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(CancellationToken ct)
        {
            var query = new GetProfileQuery
            {
                PlayerId = _currentUserService.PlayerId
            };

            return Ok(await _mediator.Send(query, ct));
        }

        [HttpPatch("nickname")]
        public async Task<IActionResult> ChangeNickname(
            [FromBody] ChangeNicknameRequest request,  
            CancellationToken ct)
        {
            var command = new ChangeNicknameCommand
            {
                PlayerId = _currentUserService.PlayerId,
                NewNickname = request.NewNickname
            };

            await _mediator.Send(command, ct);

            return NoContent();
        }
    }
}
