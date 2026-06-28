using System.Collections.Generic;

namespace GameTest.Domain.Entities;

public class Player
{
    public int Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public int Gold { get; private set; }
    public int Level { get; private set; }
    public int TotalKills { get; private set; }
    public ICollection<PlayerUnit> Units { get; private set; } = [];
    public ICollection<PlayerWeapon> Weapons { get; private set; } = [];
    public ICollection<PlayerItem> Items { get; private set; } = [];

    private Player() { }

    public Player(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Gold = 0;
        Level = 1;
        TotalKills = 0;
    }

    public void AddGold(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Gold cannot be negative", nameof(amount));
        Gold += amount;
    }

    public void SpendGold(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Gold cannot be negative", nameof(amount));
        if (Gold < amount)
            throw new InvalidOperationException("Not enough gold");
        Gold -= amount;
    }

    public void AddExperience(int experience)
    {
        const int EXP_PER_LEVEL = 100;
        while (experience >= EXP_PER_LEVEL)
        {
            experience -= EXP_PER_LEVEL;
            Level += 1;
        }
    }

    public void AddKill() => TotalKills += 1;
}