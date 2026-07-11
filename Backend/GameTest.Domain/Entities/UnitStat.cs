using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities;

public class UnitStat
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public UnitStatType Type { get; private set; }

    private UnitStat() { }

    public UnitStat(string name, string description, UnitStatType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Description cannot be empty");

        if (!Enum.IsDefined(typeof(UnitStatType), type))
            throw new DomainException("Invalid UnitStatType");

        Name = name;
        Description = description;
        Type = type;
    }
}       