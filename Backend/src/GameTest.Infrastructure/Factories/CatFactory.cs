using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;

namespace GameTest.Infrastructure.Factories;

public class CatFactory : ICatFactory
{
    public Cat Create(
        string name,
        string description,
        CatType type,
        int price,
        IEnumerable<(CatStat Stat, float Value)> properties)
    {
        var catProperties = properties
            .Select(property => new CatProperty(
                property.Stat,
                property.Value))
            .ToList();

        return new Cat(
            name,
            description,
            catProperties,
            type,
            price);
    }
}
