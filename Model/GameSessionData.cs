using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Threading.Channels;


class GameSessionData
{
    public GameMap GameMap { get; private set; }
    public List<Tower> TowerList { get; set; }
    public List<Enemy> EnemyList { get; set; }

    public Vector2 selectedCellCoords = new Vector2(0, 0);

    private float currentTicksSpawnEnemy = 0;

    public void Init()
    {
        GameMap = new GameMap();
        GameMap.LoadLevel();

        TowerList = new List<Tower>();
        EnemyList = new List<Enemy>();

        StartWave();
    }

    public void SpawnTower(int towerCoordX, int towerCoordY)
    {
        if (!GameMap.IsCellValidForTower(towerCoordX, towerCoordY))
            return;

        var tower = new Policeman(towerCoordX, towerCoordY, 0.0f);
        GameMap.Cells[towerCoordX, towerCoordY] = new Cell(towerCoordX, towerCoordY, CellType.Tower);
        TowerList.Add(tower);
    }

    public void SpawnEnemy()
    {
        var enemy = new Zombie(GameMap.spawnCoords.X - 1, GameMap.spawnCoords.Y, 0.0f, 100);
        enemy.MoveByPath(GameMap.RoadPath, () => Console.WriteLine("end"));
        EnemyList.Add(enemy);
    }

    public void StartWave()
    {

    }

    private void updateWave(float dt)
    {
        currentTicksSpawnEnemy += dt;
        if (currentTicksSpawnEnemy > 1)
        {
            SpawnEnemy();
            currentTicksSpawnEnemy -= 1;
        }
            

    }

    public void Update(float dt)
    {
        updateWave(dt);
        foreach (var enemy in EnemyList)
        {
            enemy.MoveUpdate(dt);
            enemy.RotationUpdate();
        }
    }
}
