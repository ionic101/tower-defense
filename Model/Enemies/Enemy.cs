using Microsoft.Xna.Framework;

enum EnemyType
{
    Zombie,
    RockZombie,
    Demon
}

class Enemy : GameCharacter
{
    public EnemyType Type;
    public readonly int MaxHealth = 3;
    public int Health;

    public Enemy(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed)
    {
        Health = MaxHealth;
    }
    public Enemy(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        Health = MaxHealth;
    }

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
