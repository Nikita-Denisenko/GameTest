using GameTest.Api.Requests.Auth;
using GameTest.Application.Features.Auth.Commands.ChangeEmail;
using GameTest.Application.Features.Auth.Commands.ChangePassword;
using GameTest.Application.Features.Auth.Commands.Login;
using GameTest.Application.Features.Auth.Commands.Register;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public AuthController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterRequest request, 
            CancellationToken ct)
        {
            var command = new RegisterCommand
            {
                Nickname = request.Nickname,
                Email = request.Email,
                Password = request.Password,
            };

            return Ok(await _mediator.Send(command, ct));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request, 
            CancellationToken ct)
        {
            var command = new LoginCommand
            {
                Email = request.Email,
                Password = request.Password,
            };

            return Ok(await _mediator.Send(command, ct));
        }

        [Authorize]
        [HttpPatch("change-email")]
        public async Task<IActionResult> ChangeEmail(
            [FromBody] ChangeEmailRequest request, 
            CancellationToken ct)
        {
            var command = new ChangeEmailCommand
            {
                PlayerId = _currentUserService.PlayerId,
                NewEmail = request.NewEmail,
                Password = request.Password
            };

            await _mediator.Send(command, ct);

            return NoContent();
        }

        [Authorize]
        [HttpPatch("change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromBody] ChangePasswordRequest request, 
            CancellationToken ct)
        {
            var command = new ChangePasswordCommand
            {
                PlayerId = _currentUserService.PlayerId,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword,
            };

            await _mediator.Send(command, ct);

            return NoContent();
        }
    }
}
