namespace GameTest.Domain.Entities;

public class Stats
{
    public int MaxHealth { get; private set; }
    public int Damage { get; private set; }
    public int Armor { get; private set; }
    public double MoveSpeed { get; private set; }
    public double HealthRegen { get; private set; }
    public double AttackSpeed { get; private set; }
    public double AreaSize { get; private set; }
    public double ProjectileSpeed { get; private set; }
    public double EffectDuration { get; private set; }
    public double CritChance { get; private set; }
    public double CritDamage { get; private set; }
    public double LifeSteal { get; private set; }
    public double Luck { get; private set; }
    public double PickupRadius { get; private set; }
    public double ExperienceMultiplier { get; private set; }
    public double GoldMultiplier { get; private set; }

    private Stats() { }

    public Stats(
        int maxHealth,
        int damage,
        int armor,
        double moveSpeed,
        double healthRegen,
        double attackSpeed,
        double areaSize,
        double projectileSpeed,
        double effectDuration,
        double critChance,
        double critDamage,
        double lifeSteal,
        double luck,
        double pickupRadius,
        double experienceMultiplier,
        double goldMultiplier)
    {
        MaxHealth = maxHealth;
        Damage = damage;
        Armor = armor;
        MoveSpeed = moveSpeed;
        HealthRegen = healthRegen;
        AttackSpeed = attackSpeed;
        AreaSize = areaSize;
        ProjectileSpeed = projectileSpeed;
        EffectDuration = effectDuration;
        CritChance = critChance;
        CritDamage = critDamage;
        LifeSteal = lifeSteal;
        Luck = luck;
        PickupRadius = pickupRadius;
        ExperienceMultiplier = experienceMultiplier;
        GoldMultiplier = goldMultiplier;
    }
}