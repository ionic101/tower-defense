using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

class GameSessionData
{
    public GameMap GameMap { get; private set; }
    public List<Tower> TowerList { get; set; }
    public List<Enemy> EnemyList { get; set; }

    public Vector2 selectedCellCoords = new Vector2(0, 0);
    public TowerType selectedTowerType;
    public Dictionary<Vector2, TowerType> towerButtonsLocations = new Dictionary<Vector2, TowerType>();
    public Dictionary<TowerType, int> costTowers = new Dictionary<TowerType, int>()
    {
        {TowerType.Policeman, 200 },
        {TowerType.Soldier, 800 },
        {TowerType.Sniper, 450 },
        {TowerType.Rocketman, 900 }
    };
    public int Money = 900;

    private WaveSpawner waveSpawner;

    public void Init()
    {
        GameMap = new GameMap();
        GameMap.LoadLevel();

        TowerList = new List<Tower>();
        EnemyList = new List<Enemy>();

        waveSpawner = new WaveSpawner(this);
    }

    public void EarnMoney(int money)
    {
        Money += money;
    }

    public void SpawnTower(int towerCoordX, int towerCoordY)
    {
        if (Money < costTowers[selectedTowerType])
            return;
        else
            Money -= costTowers[selectedTowerType];

        Tower tower;

        switch (selectedTowerType)
        {
            case TowerType.Policeman:
                tower = new Policeman(towerCoordX, towerCoordY, 0.0f, EnemyList, EarnMoney);
                break;
            case TowerType.Soldier:
                tower = new Soldier(towerCoordX, towerCoordY, 0.0f, EnemyList, EarnMoney);
                break;
            case TowerType.Sniper:
                tower = new Sniper(towerCoordX, towerCoordY, 0.0f, EnemyList, EarnMoney);
                break;
            case TowerType.Rocketman:
                tower = new Rocketman(towerCoordX, towerCoordY, 0.0f, EnemyList, EarnMoney);
                break;
            default:
                tower = new Policeman(towerCoordX, towerCoordY, 0.0f, EnemyList, EarnMoney);
                break;
        }

        GameMap.Cells[towerCoordX, towerCoordY] = new Cell(towerCoordX, towerCoordY, CellType.Tower);
        TowerList.Add(tower);
    }

    public void Update(float dt)
    {
        waveSpawner.Update(dt);

        foreach (var tower in TowerList)
        {
            tower.Update(dt);
        }

        var deadEnemies = new List<Enemy>();

        foreach (var enemy in EnemyList)
        {
            if (!enemy.IsAlive())
                deadEnemies.Add(enemy);
            else
                enemy.Update(dt);
        }
        
        foreach (var deadEnemy in deadEnemies)
        {
            EnemyList.Remove(deadEnemy);
        }
    }
}
