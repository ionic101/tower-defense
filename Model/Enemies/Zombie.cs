using Microsoft.Xna.Framework;
using System;

class GiantZombie : Enemy
{
    public GiantZombie(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Type = EnemyType.GiantZombie;
        SetSpeed(50);
    }
    public GiantZombie(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Type = EnemyType.GiantZombie;
        SetSpeed(50);
    }
}
