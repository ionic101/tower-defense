using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class GameMap
{
    public static string DefaultLevelPath
    {
        get
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Content", "levels", "DefaultLevel.txt");
        }
    }

    private int _mapWidth;
    private int _mapHeight;
    public int MapWidth => _mapWidth;
    public int MapHeight => _mapHeight;

    public Cell[,] Cells;

    public void LoadLevel(string levelDataPath=null)
    {
        if (levelDataPath == null)
            levelDataPath = DefaultLevelPath;

        string[] lines = File.ReadAllLines(levelDataPath);

        _mapHeight = lines.Length;
        _mapWidth = lines[0].Length;
        Settings.CellSize = Settings.ScreenHeight / MapHeight;
        Cells = new Cell[MapWidth, MapHeight];

        for (int x = 0; x < MapWidth; x++)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                switch (lines[y][x])
                {
                    case 'e':
                        Cells[x, y] = new Cell(x, y, CellType.Empty);
                        break;
                    case 'r':
                        Cells[x, y] = new Cell(x, y, CellType.Road);
                        break;
                    case 's':
                        Cells[x, y] = new Cell(x, y, CellType.Start);
                        break;
                    default:
                        throw new Exception($"Don't know {lines[y][x]} cell format");
                }
            }
        }
    }

    public void SpawnTower(int x, int y)
    {
        Cells[x, y] = new Cell(x, y, CellType.Tower);
    }

    public bool IsCellValidForTower(int x, int y)
    {
        if (x >= MapWidth || y >= MapHeight)
            return false;

        var cellType = Cells[x, y].Type;
        return cellType != CellType.Tower && cellType != CellType.Road && cellType != CellType.Start;
    }
}
