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

    public PlayerUnit(int playerId, int unitId)
    {
        PlayerId = playerId;
        UnitId = unitId;
    }
}