namespace AdventOfCode.Lib.Geometry;

public sealed class Coordinate
{
    public int X { get; init; }

    public int Y { get; init; }

    public char Value { get; set; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";

    public override bool Equals(object? obj)
    {
        if (obj is not Coordinate other)
        {
            return false;
        }
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}
