using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Policeman : Tower
{
    public Policeman(Coordinate location, float rotation) : base(location, rotation) { }
    public Policeman(float x, float y, float rotation) : base(x, y, rotation) { }
}
