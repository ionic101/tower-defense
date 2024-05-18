using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;


class GameSessionData
{
    public GameMap GameMap { get; private set; }
    public List<Tower> TowerList { get; set; }

    public Coords selectedCellCoords = new Coords(0, 0);

    public void Init()
    {
        GameMap = new GameMap();
        GameMap.LoadLevel();

        TowerList = new List<Tower>();
    }

    public void SpawnTower(int towerCoordX, int towerCoordY)
    {
        if (!GameMap.IsCellValidForTower(towerCoordX, towerCoordY))
            return;

        var tower = new Policeman(new Coords(towerCoordX, towerCoordY));
        GameMap.Cells[towerCoordX, towerCoordY] = new Cell(towerCoordX, towerCoordY, CellType.Tower);
        TowerList.Add(tower);
    }
}
