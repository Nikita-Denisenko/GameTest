using GameTest.Domain.Validators;
using System.Collections.Generic;

namespace GameTest.Domain.Entities;

public class Player
{
    public int Id { get; private set; }
    public string Nickname { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTime RegisteredAt {  get; private set; }
    public int Gold { get; private set; }
    public int TotalKills { get; private set; }

    private readonly List<PlayerUnit> _units = [];
    public IReadOnlyCollection<PlayerUnit> Units => _units;

    private readonly List<PlayerWeapon> _weapons = [];
    public IReadOnlyCollection<PlayerWeapon> Weapons => _weapons;

    private readonly List<PlayerItem> _items = [];
    public IReadOnlyCollection<PlayerItem> Items => _items;

    private readonly List<Run> _runs = [];
    public IReadOnlyCollection<Run> Runs => _runs;

    private Player() { }

    public Player(
        string nickname,
        string email, 
        string passwordHash)
   
    {
        if (string.IsNullOrWhiteSpace(nickname))
            throw new ArgumentException("Nickname cannot be empty", nameof(nickname));

        if (!EmailValidator.IsValid(email))
            throw new ArgumentException(
                "Email format is invalid",
                nameof(email));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(nameof(passwordHash));

        Nickname = nickname;
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;
        RegisteredAt = DateTime.UtcNow;
        Gold = 0;
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

    public void AddKills(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Kills cannot be negative", nameof(amount));
        TotalKills += amount;
    }

    public void ChangeNickname(string newNickname)
    {
        if (string.IsNullOrWhiteSpace(newNickname))
            throw new ArgumentException("Nickname cannot be empty", nameof(newNickname));
        Nickname = newNickname;
    }

    public void ChangeEmail(string newEmail)
    {
        if (!EmailValidator.IsValid(newEmail))
            throw new ArgumentException(
                "Email format is invalid",
                nameof(newEmail));

        Email = newEmail;
    }

    public void ChangePassword(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new ArgumentException("Email cannot be empty", nameof(newPassword));
        Email = newPassword;
    }

    public void AddUnit(PlayerUnit unit) => _units.Add(unit);
    public void AddWeapon(PlayerWeapon weapon) => _weapons.Add(weapon);
    public void AddItem(PlayerItem item) => _items.Add(item);
}
