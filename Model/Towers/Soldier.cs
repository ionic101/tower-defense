using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class Soldier : Tower
{
    public Soldier(Vector2 location, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(location, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Soldier;
        ReloadTime = 200;
        ShootRadius = 5;
        ShootDamage = 1;
    }
    public Soldier(float x, float y, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(x, y, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Soldier;
        ReloadTime = 200;
        ShootRadius = 5;
        ShootDamage = 1;
    }
}
