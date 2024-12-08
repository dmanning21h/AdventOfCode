namespace AdventOfCode.Lib.Geometry;

public sealed class Grid2D
{
    public List<List<Coordinate>> Coordinates { get; init; }

    public Grid2D(List<List<char>> charGrid2D)
    {
        Coordinates = [];
        foreach (var row in charGrid2D)
        {
            List<Coordinate> coords = [];
            foreach (var item in row)
            {
                int x = row.IndexOf(item);
                int y = charGrid2D.IndexOf(row);
                coords.Add(new Coordinate(x, y) { Value = item });
            }

            Coordinates.Add(coords);
        }
    }

    public char this[Coordinate coordinate]
    {
        get
        {
            return Coordinates[coordinate.Y][coordinate.X].Value;
        }
    }

    public bool Contains(Coordinate coordinate)
    {
        return coordinate.Y >= 0 && coordinate.Y < Coordinates.Count && coordinate.X >= 0 && coordinate.X < Coordinates[coordinate.Y].Count;
    }

    public bool Contains(int x, int y)
    {
        return y >= 0 && y < Coordinates.Count && x >= 0 && x < Coordinates[y].Count;
    }
}
