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
        int level, 
        ItemEffectType effectType, 
        float staticBonus, 
        float temporaryBonus,
        IEnumerable<ItemUpgradeLevel> levels)
    {
        Id = id;
        Name = name;
        Type = type;
        Level = level;
        EffectType = effectType;
        StaticBonus = staticBonus;
        TemporaryBonus = temporaryBonus;
        _levels.AddRange(levels);
    }

    public void UpLevel()
    {
        var level = _levels
               .FirstOrDefault(x => x.Level == Level + 1);

        if (level == null)
        {
            throw new SimulationException(
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

