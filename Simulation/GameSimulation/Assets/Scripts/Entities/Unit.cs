using Assets.Scripts.Entities;
using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

public class Unit
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public UnitType Type { get; private set; }
    public PassiveAbility PassiveAbility { get; private set; }

    private readonly List<UnitProperty> _properties
        = new List<UnitProperty>();

    public IReadOnlyCollection<UnitProperty> Properties
        => _properties;

    private readonly List<UpgradeLevel> _levels
        = new List<UpgradeLevel>();

    public IReadOnlyCollection<UpgradeLevel> Levels
        => _levels;

    public Unit(
        int id,
        string name, 
        int level, 
        UnitType type,
        PassiveAbility passiveAbility,
        IEnumerable<UnitProperty> properties,
        IEnumerable<UpgradeLevel> levels)
    {
        Id = id;
        Name = name;
        Level = level;
        Type = type;
        PassiveAbility = passiveAbility;
        _properties.AddRange(properties);
        _levels.AddRange(levels);
    }

    public void UpLevel()
    {
        if (!HasNextLevel())
            throw new SimulationException(
                $"You already have maximum level for unit with ID {Id}");

        Level++;

        foreach (var property in _properties)
        {
            property.SetBonusAtUnitLevel(Level);
        }
    }

    private bool HasNextLevel()
    {
        return _levels.Any(x => x.Level == Level + 1);
    }

    private int? GetNextLevelPrice()
    {
        var nextLevel = _levels
            .FirstOrDefault(l => l.Level == Level + 1);

        return nextLevel?.Price;
    }

    public NextLevelUnitInfo GetNextLevelInfo()
    {
        if (!HasNextLevel())
            return null;

        var propertiesInfo = _properties
            .Select(p => new NextLevelUnitPropertyInfo(
                p.Name,
                p.StatType,
                p.GetNextLevelBonus(Level))
            ).ToList();

        return new NextLevelUnitInfo(Level + 1, GetNextLevelPrice(), propertiesInfo);
    }

    public float GetPropertyTotalValue(UnitStatType statType)
    {
        var property = _properties
            .FirstOrDefault(p => p.StatType == statType);

        if (property == null)
            throw new SimulationException(
                $"Unit does not have property with type {statType}");

        return property.TotalValue;
    }
}
