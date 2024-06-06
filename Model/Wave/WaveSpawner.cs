using System;
using System.Collections.Generic;
using System.Linq;

class WaveSpawner
{
    private List<Operation> operations;
    private float countWaveTicks = 0;
    private float delayTicks = 0;
    private int operationIndex = 0;

    private GameSessionData sessionData;

    public WaveSpawner(GameSessionData sessionData)
    {
        operations = WaveLoader.GetWave();
        this.sessionData = sessionData;
    }

    public void SpawnEnemy(EnemyType enemyType)
    {
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Zombie:
                enemy = new Zombie(sessionData.GameMap.spawnCoords.X - 1, sessionData.GameMap.spawnCoords.Y, 0.0f);
                break;
            case EnemyType.StoneZombie:
                enemy = new StoneZombie(sessionData.GameMap.spawnCoords.X - 1, sessionData.GameMap.spawnCoords.Y, 0.0f);
                break;
            case EnemyType.FastZombie:
                enemy = new FastZombie(sessionData.GameMap.spawnCoords.X - 1, sessionData.GameMap.spawnCoords.Y, 0.0f);
                break;
            case EnemyType.GiantZombie:
                enemy = new GiantZombie(sessionData.GameMap.spawnCoords.X - 1, sessionData.GameMap.spawnCoords.Y, 0.0f);
                break;
        }

        enemy.MoveByPath(sessionData.GameMap.RoadPath, () => Console.WriteLine("end"));
        sessionData.EnemyList.Add(enemy);
    }

    public void Update(float dt)
    {
        countWaveTicks += dt;

        if (countWaveTicks < delayTicks || operationIndex >= operations.Count())
            return;

        var curOperation = operations[operationIndex];

        switch (curOperation.Type)
        {
            case OperationType.NewWave:
                Console.WriteLine("Wave: " + ((NewWaveOperation)curOperation).waveIndex);
                break;
            case OperationType.SpawnEnemy:
                SpawnEnemy(((SpawnEnemyOperation)curOperation).enemyType);
                break;
            case OperationType.Delay:
                delayTicks = ((DelayOperation)curOperation).delayTime;
                countWaveTicks = 0;
                break;
        }

        operationIndex++;
    }
}
