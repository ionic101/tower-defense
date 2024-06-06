using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Soldier : Tower
{
    public Soldier(Vector2 location, float rotation, List<Enemy> enemyList) : base(location, rotation, enemyList)
    {
        Type = TowerType.Soldier;
        ReloadTime = 200;
        ShootRadius = 5;
        ShootDamage = 1;
    }
    public Soldier(float x, float y, float rotation, List<Enemy> enemyList) : base(x, y, rotation, enemyList)
    {
        Type = TowerType.Soldier;
        ReloadTime = 200;
        ShootRadius = 5;
        ShootDamage = 1;
    }
}
