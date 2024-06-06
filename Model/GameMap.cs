using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

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
    public Vector2 spawnCoords { get; private set; }


    private List<Vector2> _roadPath;
    public List<Vector2> RoadPath {
        get
        {
            if (_roadPath == null)
            {
                _roadPath = getRoadPath();
            }

            return _roadPath;
        }
    }

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
                        Cells[x, y] = new Cell(x, y, CellType.Road);
                        spawnCoords = new Vector2(x, y);
                        break;
                    default:
                        throw new Exception($"Don't know {lines[y][x]} cell format");
                }
            }
        }
    }

    private List<Vector2> getRoadPath()
    {
        var directions = new Vector2[]
        {
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0),
            new Vector2(0, -1)
        };

        var roadPath = new List<Vector2>();
        var visitedCells = new HashSet<Cell>();

        var lastCell = Cells[(int)spawnCoords.X, (int)spawnCoords.Y];
        var lastDirection = new Vector2(1, 0);
        visitedCells.Add(lastCell);

        while (true)
        {
            var exit = true;

            foreach (var direction in directions)
            {
                var newCoord = lastCell.Coord + direction;
                if (newCoord.X >= MapWidth || newCoord.X < 0 || newCoord.Y >= MapHeight || newCoord.Y < 0)
                    continue;

                
                var newCell = Cells[(int)newCoord.X, (int)newCoord.Y];
                if (!visitedCells.Contains(newCell) && newCell.Type == CellType.Road)
                {
                    if (!direction.Equals(lastDirection))
                    {
                        roadPath.Add(lastCell.Coord);
                        lastDirection = direction;
                    }

                    lastCell = newCell;
                    exit = false;
                    break;
                }
            }

            visitedCells.Add(lastCell);

            if (exit)
                break;
        }

        roadPath.Add(lastCell.Coord);

        return roadPath;
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
