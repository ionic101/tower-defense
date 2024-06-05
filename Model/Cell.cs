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
    public Vector2 Coord { get; set; }
    public CellType Type { get; set; }

    public Cell(Vector2 coord, CellType type)
    {
        Coord = coord;
        Type = type;
    }

    public Cell(int x, int y, CellType type)
    {
        Coord = new Vector2(x, y);
        Type = type;
    }
}
