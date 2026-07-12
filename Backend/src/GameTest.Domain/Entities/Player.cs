using GameTest.Domain.Exceptions;
using GameTest.Domain.Validators;

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
            throw new DomainException("Nickname cannot be empty");

        if (!EmailValidator.IsValid(email))
            throw new DomainException("Email format is invalid");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("Password hash cannot be empty");

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
            throw new DomainException("Gold cannot be negative");
        Gold += amount;
    }

    public void SpendGold(int amount)
    {
        if (amount < 0)
            throw new DomainException("Gold cannot be negative");
        if (Gold < amount)
            throw new DomainException("Not enough gold");
        Gold -= amount;
    }

    public void AddKills(int amount)
    {
        if (amount < 0)
            throw new DomainException("Kills cannot be negative");
        TotalKills += amount;
    }

    public void ChangeNickname(string newNickname)
    {
        if (string.IsNullOrWhiteSpace(newNickname))
            throw new DomainException("Nickname cannot be empty");
        Nickname = newNickname;
    }

    public void ChangeEmail(string newEmail)
    {
        if (!EmailValidator.IsValid(newEmail))
            throw new DomainException("Email format is invalid");

        Email = newEmail.Trim().ToLowerInvariant();
    }

    public void ChangePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new DomainException("Password hash cannot be empty");
        PasswordHash = newPasswordHash;
    }

    public void AddUnit(PlayerUnit unit) => _units.Add(unit);
    public void AddWeapon(PlayerWeapon weapon) => _weapons.Add(weapon);
    public void AddItem(PlayerItem item) => _items.Add(item);
}
