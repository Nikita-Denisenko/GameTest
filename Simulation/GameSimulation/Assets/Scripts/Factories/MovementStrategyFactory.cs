using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Strategies.Movement;

namespace Assets.Scripts.Factories
{
    public class MovementStrategyFactory
    {
        public IMovementStrategy Create(
            EnemyMovementType movementType)
        {
            return movementType switch
            {
                EnemyMovementType.FollowPlayer =>
                    new FollowPlayerMovementStrategy(),

                EnemyMovementType.KeepDistance =>
                    new KeepDistanceMovementStrategy(),

                _ =>
                    throw new InvalidEnemyStateException(
                        $"Unknown enemy movement type: {movementType}")
            };
        }
    }
}