using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities;

public class PlayerUnit
{
    public int Id { get; private set; }
    public int PlayerId { get; private set; }
    public Player Player { get; private set; } = null!;
    public int UnitId { get; private set; }
    public Unit Unit { get; private set; } = null!;

    private readonly List<PlayerUnitProperty> _properties = [];
    public IReadOnlyCollection<PlayerUnitProperty> Properties => _properties;

    private PlayerUnit() { }

    public PlayerUnit(Unit unit)
    {
        UnitId = unit.Id;
        Unit = unit;

        foreach (var property in unit.Properties)
        {
            _properties.Add(
                new PlayerUnitProperty(property)
            );
        }
    }

    public void UpPropertyLevel(int playerUnitPropertyId)
    {
        var property = _properties.FirstOrDefault(p => p.Id == playerUnitPropertyId);
        if (property == null)
            throw new NotFoundException($"Property with id {playerUnitPropertyId} was not found!");
        property.UpLevel();
    }
}