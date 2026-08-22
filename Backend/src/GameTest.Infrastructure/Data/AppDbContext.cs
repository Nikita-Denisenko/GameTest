using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GameTest.Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Weapon> Weapons { get; set; } = null!;
    public DbSet<WeaponStat> WeaponStats { get; set; } = null!;
    public DbSet<WeaponProperty> WeaponProperties { get; set; } = null!;
    public DbSet<PlayerWeapon> PlayerWeapons { get; set; } = null!;
    public DbSet<PlayerWeaponProperty> PlayerWeaponProperties { get; set; } = null!;

    public DbSet<Unit> Units { get; set; } = null!;
    public DbSet<UnitStat> UnitStats { get; set; } = null!;
    public DbSet<UnitProperty> UnitProperties { get; set; } = null!;
    public DbSet<PlayerUnit> PlayerUnits { get; set; } = null!;
    public DbSet<PlayerUnitProperty> PlayerUnitProperties { get; set; } = null!;

    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<PlayerItem> PlayerItems { get; set; } = null!;

    public DbSet<Enemy> Enemies { get; set; } = null!;
    public DbSet<EnemyStat> EnemyStats { get; set; } = null!;
    public DbSet<EnemyProperty> EnemyProperties { get; set; } = null!;

    public DbSet<Run> Runs { get; set; } = null!;
    public DbSet<Wave> Waves { get; set; } = null!;
    public DbSet<PlayerLevel> PlayerLevels { get; set; } = null!;
    public DbSet<Arena> Arenas { get; set; } = null!;
    public DbSet<Cat> Cats { get; set; } = null!;
    public DbSet<CatStat> CatStats { get; set; } = null!;
    public DbSet<CatProperty> CatProperties { get; set;  } = null!;

    public new DatabaseFacade Database => base.Database;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
