using GameTest.Domain.Entities;
using GameTest.Domain.Enums;

namespace GameTest.Application.Interfaces;

public interface ICatFactory
{
    Cat Create(
        string name,
        string description,
        CatType type,
        int price,
        IEnumerable<(CatStat Stat, float Value)> properties);
}
