using Assets.Scripts.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface ICatalogApiClient
    {
        Task<IReadOnlyCollection<EnemyData>> GetEnemiesAsync();
        Task<IReadOnlyCollection<EnemyStatData>> GetEnemyStatsAsync();

        Task<IReadOnlyCollection<ItemData>> GetItemsAsync();

        Task<IReadOnlyCollection<UnitData>> GetUnitsAsync();
        Task<IReadOnlyCollection<UnitStatData>> GetUnitStatsAsync();

        Task<IReadOnlyCollection<WeaponData>> GetWeaponsAsync();
        Task<IReadOnlyCollection<WeaponStatData>> GetWeaponStatsAsync();

        Task<IReadOnlyCollection<WaveData>> GetWavesAsync();
    }
}
