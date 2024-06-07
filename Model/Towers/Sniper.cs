using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class Sniper : Tower
{
    public Sniper(Vector2 location, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(location, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Sniper;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 5;
    }
    public Sniper(float x, float y, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(x, y, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Sniper;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 5;
    }
}
