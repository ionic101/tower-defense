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
    public Coordinate Coord { get; set; }
    public CellType Type { get; set; }

    public Cell(Coordinate coord, CellType type)
    {
        Coord = coord;
        Type = type;
    }

    public Cell(int x, int y, CellType type)
    {
        Coord = new Coordinate(x, y);
        Type = type;
    }
}
