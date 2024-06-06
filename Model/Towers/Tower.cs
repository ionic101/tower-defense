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
    public TowerType Type;
    private List<Enemy> enemyList;
    public readonly int ShootRadius = 3;
    public readonly int Damage = 1;

    private float reloadTime = 1000;
    private float curTime = 0;

    private Enemy targetEnemy;

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
        foreach (var enemy in enemyList)
        {
            if (Vector2.Distance(enemy.Location, Location) <= ShootRadius)
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

        LookAt(targetEnemy.Location.X, targetEnemy.Location.Y);
        targetEnemy.GetDamage(Damage);

        if (!targetEnemy.IsAlive())
            targetEnemy = null;
    }

    public void Update(float dt)
    {
        curTime += dt;

        if (curTime < reloadTime)
            return;

        if (targetEnemy != null && !IsInRadius(targetEnemy.Location, ShootRadius))
        {
            targetEnemy = null;
        }

        if (targetEnemy == null)
            FindTarget();

        if (targetEnemy != null)
        {
            Shoot();
            curTime = 0;
        }
    }
}
