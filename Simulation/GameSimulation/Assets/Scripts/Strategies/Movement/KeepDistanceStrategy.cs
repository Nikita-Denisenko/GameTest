using UnityEngine;
using Assets.Scripts.Entities;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Strategies.Movement
{
    public class KeepDistanceMovementStrategy : IMovementStrategy
    {
        private readonly float _minDistance;
        private readonly float _maxDistance;

        public KeepDistanceMovementStrategy(
            float minDistance = 5,
            float maxDistance = 8)
        {
            _minDistance = minDistance;
            _maxDistance = maxDistance;
        }

        public Vector2 GetDirection(
            Enemy enemy,
            PlayerUnit player)
        {
            Vector2 direction = player.Position - enemy.Position;

            float distance = direction.magnitude;

            if (distance < _minDistance)
            {
                return -direction;
            }

            if (distance > _maxDistance)
            {
                return direction;
            }

            return Vector2.zero;
        }
    }
}