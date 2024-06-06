using System;
using Microsoft.Xna.Framework;

public enum EnemyType
{
    Zombie,
    StoneZombie,
    FastZombie,
    GiantZombie
}

class Enemy : GameCharacter
{
    public EnemyType Type;
    public int MaxHealth;
    public int Health;

    public Enemy(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed) { }
    public Enemy(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed) { }

    public void GetDamage(int damage)
    {
        Health -= damage;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void Update(float dt)
    {
        MoveUpdate(dt);
        RotationUpdate();
    }
}
