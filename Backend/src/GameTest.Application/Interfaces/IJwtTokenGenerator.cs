using GameTest.Domain.Entities;

namespace GameTest.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Player player);
    }
}
