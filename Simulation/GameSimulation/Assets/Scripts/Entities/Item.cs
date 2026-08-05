using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public int Level { get; private set; }
    public ItemEffectType EffectType {  get; private set; }
    public float StaticBonus { get; private set; }
    public float TemporaryBonus { get; private set; }
    
    private readonly List<ItemUpgradeLevel> _levels 
        = new List<ItemUpgradeLevel>();

    public IReadOnlyCollection<ItemUpgradeLevel> Levels 
        => _levels;

    public float TotalBonus => StaticBonus + TemporaryBonus;

    public Item(
        int id, 
        string name, 
        ItemType type, 
        ItemEffectType effectType, 
        float staticBonus, 
        IEnumerable<ItemUpgradeLevel> levels)
    {
        if (id <= 0)
            throw new InvalidItemStateException(
                $"Item ID must be greater than 0.");

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidItemStateException(
                $"Item name cannot be empty.");

        if (staticBonus < 0)
            throw new InvalidItemStateException(
                $"Item static bonus must be greater than or equal to 0.");

        if (levels == null || !levels.Any())
            throw new InvalidItemStateException(
                $"Item with ID {id} must have at least one upgrade level");

        Id = id;
        Name = name;
        Type = type;
        Level = 1;
        EffectType = effectType;
        StaticBonus = staticBonus;
        TemporaryBonus = 0;
        _levels.AddRange(levels);
    }

    public void UpLevel()
    {
        var level = _levels
               .FirstOrDefault(x => x.Level == Level + 1);

        if (level == null)
        {
            throw new InvalidItemStateException(
                $"You already have maximum level for Item with ID {Id}");
        }

        Level++;
        TemporaryBonus = level.Bonus;
    }
    
    public NextLevelItemInfo GetNextLevelItemInfo()
    {
        var nextLevel = _levels
            .FirstOrDefault(l => l.Level == Level + 1);

        if (nextLevel == null)
            return null;

        return new NextLevelItemInfo(Level + 1, nextLevel.Bonus, nextLevel.Price);
    }
}

