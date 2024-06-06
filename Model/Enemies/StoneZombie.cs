using Microsoft.Xna.Framework;
using System;

class StoneZombie : Enemy
{
    public StoneZombie(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed)
    {
        MaxHealth = 10;
        Health = MaxHealth;
        Type = EnemyType.StoneZombie;
        SetSpeed(70);
    }
    public StoneZombie(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        MaxHealth = 10;
        Health = MaxHealth;
        Type = EnemyType.StoneZombie;
        SetSpeed(70);
    }
}
