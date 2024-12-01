using AdventOfCode.Lib;

namespace AdventOfCode.Y2023.Day05;

public sealed class Solution : ISolution
{
    public string input { get; init; }

    public Solution(string rawInput)
    {
        input = rawInput;
    }

    public string SolvePartOne()
    {
        var almanac = new Almanac(input);
        var locationIds = almanac.Seeds.Select(s => s.LocationId);

        return locationIds.Min().ToString();
    }

    public string SolvePartTwo()
    {
        var almanac = new Almanac(input, true);
        var locationIds = almanac.Seeds.Select(s => s.LocationId);

        return locationIds.Min().ToString();
    }
}
