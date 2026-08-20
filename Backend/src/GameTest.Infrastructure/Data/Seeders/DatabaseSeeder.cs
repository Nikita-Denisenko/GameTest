namespace GameTest.Infrastructure.Data.Seeders;

public class DatabaseSeeder
{
    private readonly ArenaSeeder _arenaSeeder;
    private readonly CatStatSeeder _catStatSeeder;
    private readonly CatSeeder _catSeeder;
    private readonly EnemyStatSeeder _enemyStatSeeder;
    private readonly EnemySeeder _enemySeeder;
    private readonly ItemSeeder _itemSeeder;
    private readonly UnitStatSeeder _unitStatSeeder;
    private readonly UnitSeeder _unitSeeder;
    private readonly WeaponStatSeeder _weaponStatSeeder;
    private readonly WeaponSeeder _weaponSeeder;

    public DatabaseSeeder(
        ArenaSeeder arenaSeeder,
        CatStatSeeder catStatSeeder,
        CatSeeder catSeeder,
        EnemyStatSeeder enemyStatSeeder,
        EnemySeeder enemySeeder,
        ItemSeeder itemSeeder,
        UnitStatSeeder unitStatSeeder,
        UnitSeeder unitSeeder,
        WeaponStatSeeder weaponStatSeeder,
        WeaponSeeder weaponSeeder)
    {
        _arenaSeeder = arenaSeeder;
        _catStatSeeder = catStatSeeder;
        _catSeeder = catSeeder;
        _enemyStatSeeder = enemyStatSeeder;
        _enemySeeder = enemySeeder;
        _itemSeeder = itemSeeder;
        _unitStatSeeder = unitStatSeeder;
        _unitSeeder = unitSeeder;
        _weaponStatSeeder = weaponStatSeeder;
        _weaponSeeder = weaponSeeder;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        await _weaponStatSeeder.SeedAsync(ct);
        await _weaponSeeder.SeedAsync(ct);

        await _unitStatSeeder.SeedAsync(ct);
        await _unitSeeder.SeedAsync(ct);

        await _itemSeeder.SeedAsync(ct);

        await _enemyStatSeeder.SeedAsync(ct);
        await _enemySeeder.SeedAsync(ct);

        await _catStatSeeder.SeedAsync(ct);
        await _catSeeder.SeedAsync(ct);

        await _arenaSeeder.SeedAsync(ct);
    }
}
