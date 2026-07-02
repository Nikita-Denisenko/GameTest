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
    public Weapon StartWeapon { get; set; } = null!;
    public PassiveAbility PassiveAbility { get; set; } = null!;

    private readonly List<UnitProperty> _properties = [];
    public IReadOnlyCollection<UnitProperty> Properties => _properties;

    private Unit() { }

    public Unit(string name,
        string description,
        int startWeaponId, 
        string passiveAbilityName, 
        string passiveAbilityDescription, 
        double passiveAbilityBonus, 
        PassiveAbilityType passiveAbilityType)
    {
        Name = name;
        StartWeaponId = startWeaponId;
        Description = description;
        PassiveAbility = new PassiveAbility(passiveAbilityName, passiveAbilityBonus, passiveAbilityDescription, passiveAbilityType);
    }
}