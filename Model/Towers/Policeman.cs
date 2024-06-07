using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class Policeman : Tower
{
    public Policeman(Vector2 location, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(location, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Policeman;
        ReloadTime = 1000;
        ShootRadius = 3;
        ShootDamage = 1;
    }
    public Policeman(float x, float y, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(x, y, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Policeman;
        ReloadTime = 1000;
        ShootRadius = 3;
        ShootDamage = 1;
    }
}
