using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Policeman : Tower
{
    public Policeman(Vector2 location, float rotation, List<Enemy> enemyList) : base(location, rotation, enemyList) { }
    public Policeman(float x, float y, float rotation, List<Enemy> enemyList) : base(x, y, rotation, enemyList) { }
}
