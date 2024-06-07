using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

enum TowerType
{
    Policeman,
    Soldier,
    Sniper,
    Rocketman
}

class Tower : GameCharacter
{
    public List<Enemy> enemyList;
    public float ReloadTime;
    public float countReloadTicks = 0;
    public Enemy targetEnemy;

    public TowerType Type;
    public int ShootRadius;
    public int ShootDamage;
    public Action<int> earnMoneyAction;

    public Tower(Vector2 location, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction, float speed = 0.0f) : base(location, rotation, speed)
    {
        this.enemyList = enemyList;
        this.earnMoneyAction = earnMoneyAction;
    }

    public Tower(float x, float y, float rotation, List<Enemy> enemyList, Action<int> earnMoneyAction, float speed = 0.0f) : base(x, y, rotation, speed)
    {
        this.enemyList = enemyList;
        this.earnMoneyAction= earnMoneyAction;
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

    public virtual void Shoot()
    {
        if (targetEnemy == null)
            return;

        LookAt(targetEnemy.Location);
        targetEnemy.GetDamage(ShootDamage);

        if (!targetEnemy.IsAlive())
            targetEnemy = null;

        countReloadTicks = 0;
        
        earnMoneyAction.Invoke(ShootDamage * Settings.CoefMoney);
    }

    public bool targetIsValid()
    {
        return targetEnemy != null && IsInRadius(targetEnemy.Location, ShootRadius) && targetEnemy.IsAlive();
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
