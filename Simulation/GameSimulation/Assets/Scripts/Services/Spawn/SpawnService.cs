using Assets.Scripts.Core;
using Assets.Scripts.Entities;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Services.Spawn
{
    public class SpawnService : ISimulationService
    {
        private readonly SimulationContext _context;

        public SpawnService(SimulationContext context)
        {
            _context = context;
        }

        public void SpawnEnemy(Enemy enemy, Vector2 position)
        {
            _context.AddEnemy(enemy);
        }

        public void Update()
        {
            
        }
    }
}
