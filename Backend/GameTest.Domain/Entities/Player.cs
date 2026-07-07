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
        string email, string passwordHash,
        IEnumerable<PlayerUnit> units,
        IEnumerable<PlayerWeapon> weapons,
        IEnumerable<PlayerItem> items)
    {
        if (string.IsNullOrWhiteSpace(nickname))
            throw new ArgumentException("Nickname cannot be empty", nameof(nickname));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(nameof(email));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(nameof(passwordHash));

        if (units == null || !units.Any())
            throw new ArgumentException("Units cannot be null or empty", nameof(units));

        if (weapons == null || !weapons.Any())
            throw new ArgumentException(nameof(weapons));

        if (items == null || !items.Any())
            throw new ArgumentException(nameof(items));

        Nickname = nickname;
        Email = email;
        PasswordHash = passwordHash;
        RegisteredAt = DateTime.UtcNow;
        Gold = 0;
        TotalKills = 0;
        _units.AddRange(units);
        _weapons.AddRange(weapons);
        _items.AddRange(items);
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
}
