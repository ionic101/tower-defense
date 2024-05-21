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

    public Enemy(Coordinate location, float rotation, float speed = 0.0f) : base(location, rotation, speed) { }
    public Enemy(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed) { }
}
