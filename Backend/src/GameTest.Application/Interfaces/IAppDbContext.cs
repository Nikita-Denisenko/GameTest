using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GameTest.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Player> Players { get; }
        DbSet<Weapon> Weapons { get; }
        DbSet<WeaponStat> WeaponStats { get; }
        DbSet<WeaponProperty> WeaponProperties { get; }
        DbSet<PlayerWeapon> PlayerWeapons { get; }
        DbSet<PlayerWeaponProperty> PlayerWeaponProperties { get; }

        DbSet<Unit> Units { get; }
        DbSet<UnitProperty> UnitProperties { get; }
        DbSet<UnitStat> UnitStats { get; }
        DbSet<PlayerUnit> PlayerUnits { get; }
        DbSet<PlayerUnitProperty> PlayerUnitProperties { get; }

        DbSet<Item> Items { get; }
        DbSet<PlayerItem> PlayerItems { get; }

        DbSet<Enemy> Enemies { get; }
        DbSet<EnemyProperty> EnemyProperties { get; }
        DbSet<EnemyStat> EnemyStats { get; }

        DbSet<Run> Runs { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}