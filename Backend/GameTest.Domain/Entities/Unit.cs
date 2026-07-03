using GameTest.Domain.Enums;
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
            throw new ArgumentException("Name cannot be empty", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));

        if (!Enum.IsDefined(typeof(UnitType), type))
            throw new ArgumentException("Invalid UnitType", nameof(type));

        if (string.IsNullOrWhiteSpace(passiveAbilityName))
            throw new ArgumentException("Passive ability name cannot be empty", nameof(passiveAbilityName));

        if (string.IsNullOrWhiteSpace(passiveAbilityDescription))
            throw new ArgumentException("Passive ability description cannot be empty", nameof(passiveAbilityDescription));

        if (passiveAbilityBonus < 0)
            throw new ArgumentOutOfRangeException(nameof(passiveAbilityBonus), "Passive ability bonus cannot be negative");

        if (!Enum.IsDefined(typeof(PassiveAbilityType), passiveAbilityType))
            throw new ArgumentException("Invalid PassiveAbilityType", nameof(passiveAbilityType));

        if (properties == null || !properties.Any())
            throw new ArgumentException("Properties cannot be null or empty", nameof(properties));

        Name = name;
        Description = description;
        Type = type;
        StartWeaponId = startWeapon.Id;
        StartWeapon = startWeapon;
        PassiveAbility = new PassiveAbility(passiveAbilityName, passiveAbilityBonus, passiveAbilityDescription, passiveAbilityType);
        _properties.AddRange(properties);
    }
}