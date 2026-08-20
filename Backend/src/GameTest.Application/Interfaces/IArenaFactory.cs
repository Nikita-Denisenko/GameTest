using GameTest.Domain.Entities;

namespace GameTest.Application.Interfaces;

public interface IArenaFactory
{
    Arena Create(
        string name,
        string description,
        float width,
        float height);
}
