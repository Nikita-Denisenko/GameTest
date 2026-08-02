using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public Guid Id { get; private set; }
    public string Nickname { get; private set; }
    public PlayerUnit Unit { get; private set; }

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
        PlayerUnit unit,
        IEnumerable<PlayerLevel> levels,
        IEnumerable<Weapon> weapons,
        IEnumerable<Item> items,
        Weapon currentWeapon)
    {
        if (id == Guid.Empty)
            throw new InvalidPlayerStateException(
                $"Player ID cannot be empty.");

        if (string.IsNullOrWhiteSpace(nickname))
            throw new InvalidPlayerStateException(
                $"Player nickname cannot be empty.");

        if (unit == null)
            throw new InvalidPlayerStateException(
                $"Player unit cannot be null.");

        if (levels == null || !levels.Any())
            throw new InvalidPlayerStateException(
                $"Player must have at least one level.");

        if (weapons == null || !weapons.Any())
            throw new InvalidPlayerStateException(
                $"Player must have at least one weapon.");

        if (items == null || !items.Any())
            throw new InvalidPlayerStateException(
                $"Player must have at least one item.");

        if (currentWeapon == null)
            throw new InvalidPlayerStateException(
                $"Player current weapon cannot be null.");

        Id = id;
        Nickname = nickname;
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
            throw new InvalidPlayerStateException("Gold must be greater than 0");

        EarnedGold += gold;
    }

    public void SpendGold(int gold)
    {
        if (gold <= 0)
            throw new InvalidPlayerStateException("Gold must be greater than 0");

        if (EarnedGold < gold)
            throw new InvalidPlayerStateException($"You have not {gold} Gold to spend it.");

        EarnedGold -= gold;
    }

    public void AddKills(int kills)
    {
        if (kills <= 0)
            throw new InvalidPlayerStateException("Kills must be greater than 0");

        Kills += kills;
    }

    public void AddExperience(int experience)
    {
        if (experience <= 0)
            throw new InvalidPlayerStateException("Experience must be greater than 0");

       Experience += experience;
    }

    public void ChangeWeapon(Weapon weapon)
    {
        if (weapon == null)
            throw new InvalidPlayerStateException(
                "Weapon cannot be null.");

        CurrentWeapon = weapon;
    }

    public void PickItem(Item item)
    {
        if (item == null)
        {
            throw new InvalidPlayerStateException(
                "Item cannot be null.");
        }

        if (_items.Any(i => i.Id == item.Id))
            throw new InvalidPlayerStateException($"You already picked Item {item.Name}.");

        _items.Add(item);
    }

    public void TakeWeapon(Weapon weapon)
    {
        if (_weapons.Any(w => w.Id == weapon.Id))
            throw new InvalidPlayerStateException($"You already have Weapon {weapon.Name}.");
        _weapons.Add(weapon);
    }
}
