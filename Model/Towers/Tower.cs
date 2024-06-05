using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

enum TowerType
{
    Policeman,
    Soldar,
    Minigunner
}

class Tower : GameCharacter
{
    public TowerType Type;

    public Tower(
        Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation, speed) { }
    public Tower(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed) { }
}
