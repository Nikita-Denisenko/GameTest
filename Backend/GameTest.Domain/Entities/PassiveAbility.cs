namespace GameTest.Domain.Entities;

public class PassiveAbility
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    private PassiveAbility() { }

    public PassiveAbility(string name, string code, string description)
    {
        Name = name;
        Code = code;
        Description = description;
    }
}