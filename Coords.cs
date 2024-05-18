using System.Diagnostics.CodeAnalysis;

public struct Coords
{
    public int X;
    public int Y;

    public Coords(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Coords coord)
    {
        return coord.X == X && coord.Y == Y;
    }
}
