using UnityEngine;
using Assets.Scripts.Entities;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Strategies.Movement
{
    public class FollowPlayerMovementStrategy : IMovementStrategy
    {
        public Vector2 GetDirection(
            Enemy enemy,
            PlayerUnit player)
        {
            return player.Position - enemy.Position;
        }
    }
}