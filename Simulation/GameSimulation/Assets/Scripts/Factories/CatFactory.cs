using Assets.Scripts.Entities;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class CatFactory
    {
        private readonly SpawnPositionService _spawnPositionService;

        public CatFactory(
            SpawnPositionService spawnPositionService)
        {
            _spawnPositionService = spawnPositionService;
        }

        public Cat Create(
            CatData catData,
            IReadOnlyCollection<CatStatData> catStats,
            Vector2 playerPosition)
        {
            var properties = catData.Properties
                .Select(property =>
                {
                    var stat = catStats
                        .First(x => x.Id == property.StatId);

                    return new CatProperty(
                        property.StatName,
                        property.StatId,
                        stat.Type,
                        property.Value);
                })
                .ToList();

            return new Cat(
                catData.Id,
                catData.Name,
                _spawnPositionService.GetCatStartPosition(playerPosition),
                properties,
                catData.Type);
        }
    }
}
