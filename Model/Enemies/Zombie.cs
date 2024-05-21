using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Zombie : Enemy
{
    public Zombie(Coordinate location, float rotation, float speed = 0.0f) : base(location, rotation, speed) { }
    public Zombie(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation, speed) { }
}
