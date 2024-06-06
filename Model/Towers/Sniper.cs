using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Sniper : Tower
{
    public Sniper(Vector2 location, float rotation, List<Enemy> enemyList) : base(location, rotation, enemyList)
    {
        Type = TowerType.Sniper;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 5;
    }
    public Sniper(float x, float y, float rotation, List<Enemy> enemyList) : base(x, y, rotation, enemyList)
    {
        Type = TowerType.Sniper;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 5;
    }
}
