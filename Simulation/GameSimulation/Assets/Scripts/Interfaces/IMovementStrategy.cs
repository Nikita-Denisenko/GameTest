using UnityEngine;
using Assets.Scripts.Entities;

namespace Assets.Scripts.Interfaces
{
    public interface IMovementStrategy
    {
        Vector2 GetDirection(
            Enemy enemy,
            PlayerUnit player);
    }
}