using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;
using System.Collections.Generic;

namespace GameTest.Domain.Entities;

public class Unit
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UnitType Type { get; private set; }
    public int StartWeaponId { get; private set; }
    public Weapon StartWeapon { get; private set; } = null!;
    public PassiveAbility PassiveAbility { get; private set; } = null!;

    private readonly List<UnitProperty> _properties = [];
    public IReadOnlyCollection<UnitProperty> Properties => _properties;

    private Unit() { }

    public Unit(string name,
        string description,
        UnitType type,
        Weapon startWeapon,
        string passiveAbilityName, 
        string passiveAbilityDescription, 
        double passiveAbilityBonus, 
        PassiveAbilityType passiveAbilityType,
        IEnumerable<UnitProperty> properties)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Description cannot be empty");

        if (!Enum.IsDefined(typeof(UnitType), type))
            throw new DomainException("Invalid UnitType");

        if (string.IsNullOrWhiteSpace(passiveAbilityName))
            throw new DomainException("Passive ability name cannot be empty");

        if (string.IsNullOrWhiteSpace(passiveAbilityDescription))
            throw new DomainException("Passive ability description cannot be empty");

        if (passiveAbilityBonus < 0)
            throw new DomainException("Passive ability bonus cannot be negative");

        if (!Enum.IsDefined(typeof(PassiveAbilityType), passiveAbilityType))
            throw new DomainException("Invalid PassiveAbilityType");

        if (properties == null || !properties.Any())
            throw new DomainException("Properties cannot be null or empty");

        Name = name;
        Description = description;
        Type = type;
        StartWeaponId = startWeapon.Id;
        StartWeapon = startWeapon;
        PassiveAbility = new PassiveAbility(passiveAbilityName, passiveAbilityBonus, passiveAbilityDescription, passiveAbilityType);
        _properties.AddRange(properties);
    }
}