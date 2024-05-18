using Microsoft.Xna.Framework;

enum EnemyType
{
    Zombie,
    RockZombie,
    Demon
}

class Enemy
{
    public EnemyType Type;
    public Vector2 Coords;

    public Enemy(Vector2 coords)
    {
        Coords = coords;
    }
}
