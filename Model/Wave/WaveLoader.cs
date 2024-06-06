using System.IO;
using System;
using System.Collections.Generic;

enum OperationType
{
    NewWave,
    SpawnEnemy,
    Delay
}

class Operation
{
    public OperationType Type;
}

class NewWaveOperation : Operation
{
    public int waveIndex;

    public NewWaveOperation(int waveIndex)
    {
        Type = OperationType.NewWave;
        this.waveIndex = waveIndex;
    }
}

class SpawnEnemyOperation : Operation
{
    public EnemyType enemyType;

    public SpawnEnemyOperation(EnemyType enemyType)
    {
        Type = OperationType.SpawnEnemy;
        this.enemyType = enemyType;
    }
}

class DelayOperation : Operation
{
    public int delayTime;

    public DelayOperation(int delayTime)
    {
        Type = OperationType.Delay;
        this.delayTime = delayTime;
    }
}


static class WaveLoader
{
    public static string DefaultWavePath
    {
        get
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Content", "waves", "DefaultWave.txt");
        }
    }

    public static List<Operation> GetWave(string waveDataPath=null)
    {
        if (waveDataPath == null)
            waveDataPath = DefaultWavePath;

        string[] lines = File.ReadAllLines(waveDataPath);

        var operations = new List<Operation>();

        foreach (string line in lines)
        {
            var lineData = line.Split(" ");

            switch (lineData[0])
            {
                case "wave":
                    operations.Add(new NewWaveOperation(int.Parse(lineData[1])));
                    break;
                case "spawn":
                    for (int i = 0; i < int.Parse(lineData[2]); i++)
                    {
                        operations.Add(new SpawnEnemyOperation((EnemyType)int.Parse(lineData[1])));
                        operations.Add(new DelayOperation(int.Parse(lineData[3]) * 1000));
                    }
                    break;
                case "delay":
                    operations.Add(new DelayOperation(int.Parse(lineData[1]) * 1000));
                    break;
            }
        }

        return operations;
    }
}

