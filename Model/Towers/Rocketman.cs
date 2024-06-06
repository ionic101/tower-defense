using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Rocketman : Tower
{
    private const float explosionRadius = 3;
    public Rocketman(Vector2 location, float rotation, List<Enemy> enemyList) : base(location, rotation, enemyList)
    {
        Type = TowerType.Rocketman;
        ReloadTime = 2000;
        ShootRadius = 10;
        ShootDamage = 3;
    }
    public Rocketman(float x, float y, float rotation, List<Enemy> enemyList) : base(x, y, rotation, enemyList)
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

        foreach (var enemy in enemyList)
        {
            if (IsInRadius(enemy.Location, explosionRadius) && enemy.IsAlive())
            {
                enemy.GetDamage(ShootDamage);
            }
        }

        if (!targetEnemy.IsAlive())
            targetEnemy = null;

        countReloadTicks = 0;
    }
}
