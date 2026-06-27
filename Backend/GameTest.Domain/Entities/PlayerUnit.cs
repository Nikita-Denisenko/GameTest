namespace GameTest.Domain.Entities;

public class PlayerUnit
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    public int UnitId { get; set; }
    public Unit Unit { get; set; } = null!;
    public int Level { get; set; } = 1;

    private PlayerUnit() { }

    public PlayerUnit(int playerId, int unitId, int level = 1)
    {
        PlayerId = playerId;
        UnitId = unitId;
        Level = level;
    }

    public int GetHealth() => Unit.BaseStats.MaxHealth + (Level - 1) * 10;
    public int GetDamage() => Unit.BaseStats.Damage + (Level - 1) * 2;
    public int GetArmor() => Unit.BaseStats.Armor + (Level - 1) * 1;
    public double GetMoveSpeed() => Unit.BaseStats.MoveSpeed + (Level - 1) * 0.1;
}