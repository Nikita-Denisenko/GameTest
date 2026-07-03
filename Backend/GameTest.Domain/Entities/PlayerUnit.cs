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

    public PlayerUnit(Unit unit, IEnumerable<PlayerUnitProperty> properties)
    {
        if (properties == null || !properties.Any())
            throw new ArgumentException("Properties cannot be empty", nameof(properties));

        UnitId = unit.Id;
        Unit = unit;
        _properties.AddRange(properties);
    }

    public void UpPropertyLevel(int playerUnitPropertyId)
    {
        var property = _properties.FirstOrDefault(p => p.Id == playerUnitPropertyId);
        if (property == null)
            throw new KeyNotFoundException($"Property with id {playerUnitPropertyId} was not found!");
        property.UpLevel();
    }
}