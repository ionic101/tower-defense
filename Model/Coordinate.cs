using System;

public struct Coordinate
{
    public float X;
    public float Y;

    public Coordinate(float x, float y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Coordinate coord)
    {
        return coord.X == X && coord.Y == Y;
    }

    public double Abs()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public bool IsInRadius(Coordinate coord, float radius)
    {
        return Math.Abs(X - coord.X) <= radius && Math.Abs(Y - coord.Y) <= radius;
    }

    public Coordinate Normalized()
    {
        return this / Abs();
    }

    public static Coordinate operator +(Coordinate firstCoord, Coordinate secordCoord)
    {
        return new Coordinate(firstCoord.X + secordCoord.X, firstCoord.Y + secordCoord.Y);
    }

    public static Coordinate operator -(Coordinate firstCoord, Coordinate secondCoord)
    {
        return new Coordinate(firstCoord.X - secondCoord.X, firstCoord.Y - secondCoord.Y);
    }

    public static Coordinate operator *(Coordinate coord, double number)
    {
        return new Coordinate(coord.X * (float)number, coord.Y * (float)number);
    }

    public static Coordinate operator /(Coordinate coord, double number)
    {
        return new Coordinate(coord.X / (float)number, coord.Y / (float)number);
    }

    public override string ToString()
    {
        return X.ToString() + ' ' + Y.ToString();
    }
}
