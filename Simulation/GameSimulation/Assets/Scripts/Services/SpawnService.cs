using Assets.Scripts.Factories;
using Assets.Scripts.Game;
using Assets.Scripts.GameData;
using Assets.Scripts.ValueObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class SpawnService
    {
        private readonly GameSession _gameSession;
        private readonly Catalog _catalog;
        private readonly EnemyFactory _enemyFactory;

        private readonly List<WaveEnemyInfo> _enemiesInfo = new();

        private readonly System.Random _random = new();

        public SpawnService(
            GameSession gameSession,
            Catalog catalog,
            EnemyFactory enemyFactory)
        {
            _gameSession = gameSession;
            _catalog = catalog;
            _enemyFactory = enemyFactory;
        }

        public Vector2 GetStartPosition()
        {
            return Vector2.zero;
        }

        public void StartSpawnEnemies()
        {
            _enemiesInfo.Clear();

            var currentWave =
                _gameSession.CurrentWave;

            foreach (var waveEnemy in currentWave.Enemies)
            {
                var quantity =
                    _random.Next(
                        waveEnemy.QuantityRange.Min,
                        waveEnemy.QuantityRange.Max + 1);

                _enemiesInfo.Add(
                    new WaveEnemyInfo(
                        waveEnemy.EnemyId,
                        waveEnemy.SpawnInterval,
                        waveEnemy.SpawnInterval,
                        quantity));
            }
        }

        public void Tick(
            float deltaTime)
        {
            if (deltaTime <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(deltaTime));

            foreach (var enemyInfo in _enemiesInfo)
            {
                if (enemyInfo.IsCompleted())
                    continue;

                enemyInfo.AdvanceTime(
                    deltaTime);

                if (enemyInfo.SecondsUntilSpawn > 0)
                    continue;

                SpawnEnemy(enemyInfo);

                if (!enemyInfo.IsCompleted())
                    enemyInfo.ResetTimer();
            }
        }

        private void SpawnEnemy(
            WaveEnemyInfo enemyInfo)
        {
            var enemyData =
                _catalog.Enemies[enemyInfo.EnemyId];

            var enemy =
                _enemyFactory.Create(
                    enemyData,
                    _catalog.EnemyStats.Values,
                    GetStartPosition());

            _gameSession.AddEnemy(enemy);

            enemyInfo.AddCount();
        }
    }
}
