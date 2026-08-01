using Assets.Scripts.Exceptions;
using System;
using UnityEngine;

public abstract class Unit
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Vector2 Position { get; private set; }
    public float CurrentHealth { get; private set; }
    public float MaxHealth => GetMaxHealth();

    protected Unit(
        int id,
        string name,
        Vector2 position,
        float maxHealth)
    {
        Id = id;
        Name = name;
        Position = position;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            throw new SimulationException(
                "Damage must be greater than 0");

        CurrentHealth = Math.Max(0, CurrentHealth - damage);
    }

    public void Heal(float hp)
    {
        if (hp <= 0)
            throw new SimulationException(
                "Heal amount must be greater than 0");

        CurrentHealth = Math.Min(
            MaxHealth,
            CurrentHealth + hp);
    }

    public void Move(Vector2 direction, float distance)
    {
        if (direction == Vector2.zero)
            return;

        Position += direction.normalized * distance;
    }

    protected abstract float GetMaxHealth();
}