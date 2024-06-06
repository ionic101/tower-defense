using Microsoft.Xna.Framework;
using System.Collections.Generic;

enum TowerType
{
    Policeman,
    Soldar,
    Minigunner
}

class Tower : GameCharacter
{
    private List<Enemy> enemyList;
    private const float ReloadTime = 1000;
    private float countReloadTicks = 0;
    private Enemy targetEnemy;

    public readonly TowerType Type;
    public readonly int ShootRadius = 3;
    public readonly int ShootDamage = 1;

    public Tower(Vector2 location, float rotation, List<Enemy> enemyList, float speed = 0.0f) : base(location, rotation, speed)
    {
        this.enemyList = enemyList;
    }

    public Tower(float x, float y, float rotation, List<Enemy> enemyList, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        this.enemyList = enemyList;
    }

    public void FindTarget()
    {
        if (targetIsValid())
            return;

        targetEnemy = null;

        foreach (var enemy in enemyList)
        {
            if (IsInRadius(enemy.Location, ShootRadius))
            {
                targetEnemy = enemy;
                return;
            }
        }
    }

    public void Shoot()
    {
        if (targetEnemy == null)
            return;

        LookAt(targetEnemy.Location);
        targetEnemy.GetDamage(ShootDamage);

        if (!targetEnemy.IsAlive())
            targetEnemy = null;

        countReloadTicks = 0;
    }

    private bool targetIsValid()
    {
        return targetEnemy != null && IsInRadius(targetEnemy.Location, ShootRadius);
    }

    public void Update(float dt)
    {
        countReloadTicks += dt;

        if (countReloadTicks < ReloadTime)
            return;

        FindTarget();
        Shoot();
    }
}
