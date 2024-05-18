using Microsoft.Xna.Framework;

public enum CellType
{
    Empty,
    Start,
    Road,
    Tower
}

public struct Cell
{
    public Coords Coord { get; set; }
    public CellType Type { get; set; }

    public Cell(Coords coord, CellType type)
    {
        Coord = coord;
        Type = type;
    }

    public Cell(int x, int y, CellType type)
    {
        Coord = new Coords(x, y);
        Type = type;
    }
}
