namespace AdventOfCode.Lib.Geometry;

public static class GeometryHelper
{
    public static int GetDistance(Coordinate a, Coordinate b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static int GetDistanceX(Coordinate a, Coordinate b)
    {
        return Math.Abs(a.X - b.X);
    }

    public static int GetDistanceY(Coordinate a, Coordinate b)
    {
        return Math.Abs(a.Y - b.Y);
    }

    public static double GetSlope(Coordinate a, Coordinate b)
    {
        return (double)(b.Y - a.Y) / (b.X - a.X);
    }

}
