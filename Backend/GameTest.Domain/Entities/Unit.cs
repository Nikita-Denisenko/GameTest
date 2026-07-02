using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;
using System.Collections.Generic;

namespace GameTest.Domain.Entities;

public class Unit
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StartWeaponId { get; private set; }
    public Weapon StartWeapon { get; private set; } = null!;
    public PassiveAbility PassiveAbility { get; private set; } = null!;

    private readonly List<UnitProperty> _properties = [];
    public IReadOnlyCollection<UnitProperty> Properties => _properties;

    private Unit() { }

    public Unit(string name,
        string description,
        Weapon startWeapon,
        string passiveAbilityName, 
        string passiveAbilityDescription, 
        double passiveAbilityBonus, 
        PassiveAbilityType passiveAbilityType,
        IEnumerable<UnitProperty> properties)
    {
        Name = name;
        StartWeaponId = startWeapon.Id;
        StartWeapon = startWeapon;
        Description = description;
        PassiveAbility = new PassiveAbility(passiveAbilityName, passiveAbilityBonus, passiveAbilityDescription, passiveAbilityType);
        _properties.AddRange(properties);
    }
}