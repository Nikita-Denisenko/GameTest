using Assets.Scripts.Entities;
using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

public class Weapon
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public WeaponType Type { get; private set; }

    private readonly List<WeaponProperty> _properties
        = new List<WeaponProperty>();

    public IReadOnlyCollection<WeaponProperty> Properties 
        => _properties;

    private readonly List<UpgradeLevel> _levels 
        = new List<UpgradeLevel>();

    public IReadOnlyCollection<UpgradeLevel> Levels 
        => _levels;

    public Weapon(
        int id,
        string name,
        int level,
        WeaponType type,
        IEnumerable<WeaponProperty> properties,
        IEnumerable<UpgradeLevel> levels)
    {
        Id = id;
        Name = name;
        Level = level;
        Type = type;
        _properties.AddRange(properties);
        _levels.AddRange(levels);
    }

    public void UpLevel()
    {
        if (!HasNextLevel())
            throw new SimulationException(
                $"You already have maximum level for weapon with ID {Id}");

        Level++;
        
        foreach (var property in _properties)
        {
            property.SetBonusAtWeaponLevel(Level);
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

    public NextLevelWeaponInfo GetNextLevelInfo()
    {
        if (!HasNextLevel())
            return null;

        var propertiesInfo = _properties
            .Select(p => new NextLevelWeaponPropertyInfo(
                p.Name, 
                p.StatType, 
                p.GetNextLevelBonus(Level))
            ).ToList();

        return new NextLevelWeaponInfo(Level + 1, GetNextLevelPrice(), propertiesInfo);
    }

    public float GetPropertyTotalValue(WeaponStatType statType)
    {
        var property = _properties
            .FirstOrDefault(p => p.StatType == statType);

        if (property == null)
            throw new SimulationException(
                $"Weapon does not have property with type {statType}");

        return property.TotalValue;
    }
}
