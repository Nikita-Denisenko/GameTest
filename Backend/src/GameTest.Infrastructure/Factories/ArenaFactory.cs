using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;

namespace GameTest.Infrastructure.Factories;

public class ArenaFactory : IArenaFactory
{
    public Arena Create(
        string name,
        string description,
        float width,
        float height)
    {
        return new Arena(
            name,
            description,
            width,
            height);
    }
}
