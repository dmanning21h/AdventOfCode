using AdventOfCode.Lib.Geometry;
using AdventOfCode.Lib.Input;
using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2024.Day08;

public sealed class Solution : ISolution
{
    private readonly Grid2D grid;
    private readonly Dictionary<char, List<Coordinate>> antennas;

    public Solution(string rawInput)
    {
        grid = InputParser.ParseGrid2D(rawInput);

        antennas = [];
        foreach (var row in grid.Coordinates)
        {
            foreach (var coord in row.Where(x => !x.Value.Equals('.')))
            {
                if (!antennas.TryGetValue(coord.Value, out List<Coordinate>? value))
                {
                    value = ([]);
                    antennas[coord.Value] = value;
                }

                value.Add(coord);
            }
        }
    }

    public string SolvePartOne()
    {
        HashSet<Coordinate> uniqueAntinodes = [];

        foreach (var antenna in antennas) {
            for (int i = 0; i < antenna.Value.Count; i++)
            {
                for (int j = i + 1; j < antenna.Value.Count; j++)
                {
                    var coord1 = antenna.Value[i];
                    var coord2 = antenna.Value[j];

                    var antinodes = GetAntinodesV1(coord1, coord2);
                    foreach (var antinode in antinodes)
                    {
                        if (grid.Contains(antinode))
                        {
                            uniqueAntinodes.Add(antinode);
                        }
                    }
                }
            }
        }

        return uniqueAntinodes.Count.ToString();
    }

    public string SolvePartTwo()
    {
        HashSet<Coordinate> uniqueAntinodes = [];

        foreach (var antenna in antennas)
        {
            for (int i = 0; i < antenna.Value.Count; i++)
            {
                for (int j = i + 1; j < antenna.Value.Count; j++)
                {
                    var coord1 = antenna.Value[i];
                    var coord2 = antenna.Value[j];

                    var antinodes = GetAntinodesV2(coord1, coord2);
                    foreach (var antinode in antinodes)
                    {
                        if (grid.Contains(antinode))
                        {
                            uniqueAntinodes.Add(antinode);
                        }
                    }
                }
            }
        }

        return uniqueAntinodes.Count.ToString();
    }
    // 813 too low
    
    private static List<Coordinate> GetAntinodesV1(Coordinate coord1, Coordinate coord2)
    {
        int distanceX = GeometryHelper.GetDistanceX(coord1, coord2);
        int distanceY = GeometryHelper.GetDistanceY(coord1, coord2);

        var minX = Math.Min(coord1.X, coord2.X);
        var maxX = Math.Max(coord1.X, coord2.X);
        var minY = Math.Min(coord1.Y, coord2.Y);
        var maxY = Math.Max(coord1.Y, coord2.Y);

        List<Coordinate> antinodes = [];    
        if (coord1.X == coord2.X)
        {
            antinodes.Add(new Coordinate(coord1.X, minY - distanceY));
            antinodes.Add(new Coordinate(coord1.X, maxY + distanceY));
        }
        else if (coord1.Y == coord2.Y)
        {
            antinodes.Add(new Coordinate(minX - distanceX, coord1.Y));
            antinodes.Add(new Coordinate(maxX + distanceX, coord1.Y));
        }
        else
        {
            double slope = GeometryHelper.GetSlope(coord1, coord2);

            if (slope > 0)
            {
                antinodes.Add(new Coordinate(minX - distanceX, minY - distanceY));
                antinodes.Add(new Coordinate(maxX + distanceX, maxY + distanceY));
            }
            else
            {
                antinodes.Add(new Coordinate(minX - distanceX, maxY + distanceY));
                antinodes.Add(new Coordinate(maxX + distanceX, minY - distanceY));
            }
        }

        return antinodes;
    }

    private List<Coordinate> GetAntinodesV2(Coordinate coord1, Coordinate coord2)
    {
        int distanceX = GeometryHelper.GetDistanceX(coord1, coord2);
        int distanceY = GeometryHelper.GetDistanceY(coord1, coord2);

        var minX = Math.Min(coord1.X, coord2.X);
        var maxX = Math.Max(coord1.X, coord2.X);
        var minY = Math.Min(coord1.Y, coord2.Y);
        var maxY = Math.Max(coord1.Y, coord2.Y);

        List<Coordinate> antinodes = [coord1, coord2];
        if (coord1.X == coord2.X)
        {
            int currentMinY = minY - distanceY;
            int currentMaxY = maxY + distanceY;

            while (grid.Contains(coord1.X, currentMinY))
            {
                antinodes.Add(new Coordinate(coord1.X, currentMinY));
                currentMinY -= distanceY;
            }

            while (grid.Contains(coord1.X, currentMaxY))
            {
                antinodes.Add(new Coordinate(coord1.X, currentMaxY));
                currentMaxY += distanceY;
            }
        }
        else if (coord1.Y == coord2.Y)
        {
            int currentMinX = minX - distanceX;
            int currentMaxX = maxX + distanceX;

            while (grid.Contains(currentMinX, coord1.Y))
            {
                antinodes.Add(new Coordinate(currentMinX, coord1.Y));
                currentMinX -= distanceX;
            }

            while (grid.Contains(currentMaxX, coord1.Y))
            {
                antinodes.Add(new Coordinate(currentMaxX, coord1.Y));
                currentMaxX += distanceX;
            }
        }
        else
        {
            double slope = GeometryHelper.GetSlope(coord1, coord2);

            if (slope > 0)
            {
                int currentMinX = minX - distanceX;
                int currentMaxX = maxX + distanceX;
                int currentMinY = minY - distanceY;
                int currentMaxY = maxY + distanceY;

                while (grid.Contains(currentMinX, currentMinY))
                {
                    antinodes.Add(new Coordinate(currentMinX, currentMinY));
                    currentMinX -= distanceX;
                    currentMinY -= distanceY;
                }

                while (grid.Contains(currentMaxX, currentMaxY))
                {
                    antinodes.Add(new Coordinate(currentMaxX, currentMaxY));
                    currentMaxX += distanceX;
                    currentMaxY += distanceY;
                }
            }
            else
            {
                int currentMinX = minX - distanceX;
                int currentMaxX = maxX + distanceX;
                int currentMinY = minY - distanceY;
                int currentMaxY = maxY + distanceY;

                while (grid.Contains(currentMinX, currentMaxY))
                {
                    antinodes.Add(new Coordinate(currentMinX, currentMaxY));
                    currentMinX -= distanceX;
                    currentMaxY += distanceY;
                }

                while (grid.Contains(currentMaxX, currentMinY))
                {
                    antinodes.Add(new Coordinate(currentMaxX, currentMinY));
                    currentMaxX += distanceX;
                    currentMinY -= distanceY;
                }
            }
        }

        return antinodes;
    }
}
