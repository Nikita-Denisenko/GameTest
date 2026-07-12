using System.Security.Claims;
using GameTest.Application.Interfaces;

namespace GameTest.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int PlayerId
    {
        get
        {
            var claim = _httpContextAccessor.HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(claim, out var id))
                throw new UnauthorizedAccessException("Player id claim not found.");

            return id;
        }
    }
}