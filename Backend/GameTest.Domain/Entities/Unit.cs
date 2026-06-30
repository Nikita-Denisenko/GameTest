using System.Collections.Generic;

namespace GameTest.Domain.Entities;

public class Unit
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StartWeaponId { get; private set; }
    public Weapon StartWeapon { get; set; } = null!;
    public int PassiveAbilityId { get; private set; }
    public PassiveAbility PassiveAbility { get; set; } = null!;

    private readonly List<UnitProperty> _properties = [];
    public IReadOnlyCollection<UnitProperty> Properties => _properties;

    private Unit() { }

    public Unit(string name, int startWeaponId, int passiveAbilityId)
    {
        Name = name;
        StartWeaponId = startWeaponId;
        PassiveAbilityId = passiveAbilityId;
    }
}