using Assets.Scripts.Entities;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Services
{
    public class MovementService
    {
        public void MoveEnemy(
            Enemy enemy,
            PlayerUnit player,
            float deltaTime)
        {
            var direction =
                enemy.MovementStrategy
                    .GetDirection(enemy, player);

            enemy.Move(
                direction,
                enemy.GetPropertyValue(EnemyStatType.Speed) * deltaTime);
        }
    }
}