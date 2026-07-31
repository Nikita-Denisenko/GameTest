using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


public class Player
{
    public Guid Id { get; private set; }
    public string Nickname { get; private set; }
    public Vector2 Position { get; private set; }
    public Unit Unit { get; private set; }

    private readonly List<PlayerLevel> _levels 
        = new List<PlayerLevel>();
    public IReadOnlyCollection<PlayerLevel> Levels 
        => _levels;

    private readonly List<Weapon> _weapons 
        = new List<Weapon>();
    public IReadOnlyCollection<Weapon> Weapons 
        => _weapons;

    private readonly List<Item> _items 
        = new List<Item>();
    public IReadOnlyCollection<Item> Items 
        => _items;
  
    public Weapon CurrentWeapon { get; private set; }
    public int EarnedGold { get; private set; }
    public int Kills { get; private set; }
    public int Experience { get; private set; }
    public int Level => _levels
        .Last(l => l.Experience <= Experience).Level;

    public Player(
        Guid id,
        string nickname,
        Vector2 position,
        Unit unit,
        IEnumerable<PlayerLevel> levels,
        IEnumerable<Weapon> weapons,
        IEnumerable<Item> items,
        Weapon currentWeapon)
    {
        Id = id;
        Nickname = nickname;
        Position = position;
        Unit = unit;
        _levels.AddRange(levels);
        _weapons.AddRange(weapons);
        _items.AddRange(items);
        CurrentWeapon = currentWeapon;
        EarnedGold = 0;
        Kills = 0;
        Experience = 0;
    }

    public void AddGold(int gold)
    {
        if (gold <= 0)
            throw new SimulationException("Gold must be greater than 0");

        EarnedGold += gold;
    }

    public void SpendGold(int gold)
    {
        if (gold <= 0)
            throw new SimulationException("Gold must be greater than 0");

        if (EarnedGold < gold)
            throw new SimulationException($"You have not {gold} Gold to spend it.");

        EarnedGold -= gold;
    }

    public void AddKills(int kills)
    {
        if (kills <= 0)
            throw new SimulationException("Kills must be greater than 0");

        Kills += kills;
    }

    public void AddExperience(int experience)
    {
        if (experience <= 0)
            throw new SimulationException("Experience must be greater than 0");

       Experience += experience;
    }

    public void ChangeWeapon(Weapon weapon) => CurrentWeapon = weapon;
}
