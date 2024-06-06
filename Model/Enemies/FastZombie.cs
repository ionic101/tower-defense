using Microsoft.Xna.Framework;

class FastZombie : Enemy
{
    public FastZombie(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed)
    {
        MaxHealth = 3;
        Health = MaxHealth;
        Type = EnemyType.FastZombie;
        SetSpeed(200);
    }
    public FastZombie(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        MaxHealth = 3;
        Health = MaxHealth;
        Type = EnemyType.FastZombie;
        SetSpeed(200);
    }
}
