using GameTest.Domain.Enums;

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
            throw new ArgumentException("Name cannot be empty", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));

        if (!Enum.IsDefined(typeof(UnitStatType), type))
            throw new ArgumentException("Invalid UnitStatType", nameof(type));

        Name = name;
        Description = description;
        Type = type;
    }
}       