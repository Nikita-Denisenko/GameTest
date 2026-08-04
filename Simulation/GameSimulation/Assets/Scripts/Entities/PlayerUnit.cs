using Assets.Scripts.Entities;
using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerUnit : Unit
{
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

    public PlayerUnit(
        int id,
        string name, 
        Vector2 position,
        UnitType type,
        PassiveAbility passiveAbility,
        IReadOnlyCollection<UnitProperty> properties,
        IEnumerable<UpgradeLevel> levels) 
        : base(id, name, position, GetMaxHealth(properties))
    {

        if (passiveAbility == null)
            throw new InvalidUnitStateException(
                $"Unit with ID {id} must have a passive ability");

        if (properties == null || !properties.Any())
            throw new InvalidUnitStateException(
                $"Unit with ID {id} must have at least one property");
        
        if (levels == null || !levels.Any())
            throw new InvalidUnitStateException(
                $"Unit with ID {id} must have at least one upgrade level");

        Level = 1;
        Type = type;
        PassiveAbility = passiveAbility;
        _properties.AddRange(properties);
        _levels.AddRange(levels);
    }

    public void UpLevel()
    {
        if (!HasNextLevel())
            throw new InvalidUnitStateException(
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
            throw new InvalidUnitStateException(
                $"Unit does not have property with type {statType}");

        return property.TotalValue;
    }

    private static float GetMaxHealth(IEnumerable<UnitProperty> properties)
    {
        var property = properties
            .FirstOrDefault(p => p.StatType == UnitStatType.MaxHealth);

        if (property == null)
            throw new InvalidUnitStateException(
                "Unit must have MaxHealth property");

        return property.TotalValue;
    }

    protected override float GetMaxHealth()
    {
        return GetPropertyTotalValue(UnitStatType.MaxHealth);
    }
}
