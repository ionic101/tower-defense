using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class Rocketman : Tower
{
    private const float explosionRadius = 3;
    public Rocketman(Vector2 location, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(location, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Rocketman;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 3;
    }
    public Rocketman(float x, float y, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction) : base(x, y, rotation, enemyList, earnMoneyAction)
    {
        Type = TowerType.Rocketman;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 3;
    }

    public override void Shoot()
    {
        if (targetEnemy == null)
            return;

        LookAt(targetEnemy.Location);

        var totalMoney = 0;

        foreach (var enemy in enemyList)
        {
            if (IsInRadius(enemy.Location, explosionRadius) && enemy.IsAlive())
            {
                enemy.GetDamage(ShootDamage);
                totalMoney += ShootDamage;
            }
        }

        if (!targetEnemy.IsAlive())
            targetEnemy = null;

        countReloadTicks = 0;

        earnMoneyAction.Invoke(totalMoney * Settings.CoefMoney);
    }
}
