using Assets.Scripts.Entities;
using Assets.Scripts.Game;
using System;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class SpawnPositionService
    {
        private readonly GameSession _gameSession;

        private readonly System.Random _random = new();

        private const float MinDistanceFromPlayer = 5f;
        private const float MinDistanceFromEnemy = 1.5f;

        private const int MaxAttempts = 30;

        public SpawnPositionService(
            GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        public Vector2 GetPlayerStartPosition()
        {
            var arena = _gameSession.Arena;

            return new Vector2(
                arena.Width / 2f,
                arena.Height / 2f);
        }

        public Vector2 GetCatStartPosition(Vector2 playerPosition)
        {
            return playerPosition + new Vector2(1.5f, 0f);
        }
        public Vector2 GetFreeEnemySpawnPosition()
        {
            var arena = _gameSession.Arena;

            for (var attempt = 0;
                attempt < MaxAttempts;
                attempt++)
            {
                var position =
                    GetRandomPosition(arena);

                if (IsPositionFree(position))
                    return position;
            }

            throw new InvalidOperationException(
                "Unable to find a free enemy spawn position.");
        }

        private Vector2 GetRandomPosition(
            Arena arena)
        {
            var x =
                (float)_random.NextDouble()
                * arena.Width;

            var y =
                (float)_random.NextDouble()
                * arena.Height;

            return new Vector2(
                x,
                y);
        }

        private bool IsPositionFree(
            Vector2 position)
        {
            var playerDistance =
                Vector2.Distance(
                    position,
                    _gameSession.Player.Unit.Position);

            if (playerDistance < MinDistanceFromPlayer)
                return false;

            foreach (var enemy in _gameSession.Enemies)
            {
                var enemyDistance =
                    Vector2.Distance(
                        position,
                        enemy.Position);

                if (enemyDistance < MinDistanceFromEnemy)
                    return false;
            }

            return true;
        }
    }
}
