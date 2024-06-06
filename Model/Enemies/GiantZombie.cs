using Microsoft.Xna.Framework;
using System;

class Zombie : Enemy
{
    public Zombie(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed)
    {
        MaxHealth = 3;
        Health = MaxHealth;
        Type = EnemyType.Zombie;
        SetSpeed(100);
    }
    public Zombie(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        MaxHealth = 3;
        Health = MaxHealth;
        Type = EnemyType.Zombie;
        SetSpeed(100);
    }
}
