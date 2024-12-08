using AdventOfCode.Lib.Geometry;

namespace AdventOfCode.Lib.Input;

public static class InputParser
{
    public static string[] ParseLines(string rawInput)
    {
        return rawInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
    }

    public static Grid2D ParseGrid2D(string rawInput)
    {
        var charGrid2D = rawInput.Split("\r\n").Select(line => line.ToList()).ToList();

        return new Grid2D(charGrid2D);
    }
}
