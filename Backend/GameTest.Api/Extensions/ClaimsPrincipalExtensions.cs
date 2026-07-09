using System.Security.Claims;

namespace GameTest.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetPlayerId(this ClaimsPrincipal user)
        {
            var playerId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (playerId == null)
                throw new UnauthorizedAccessException("Player id claim not found");

            return int.Parse(playerId);
        }
    }
}