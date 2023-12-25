namespace Day05;

public sealed class Solution
{
    public string Input { get; init; }


    public Solution(string input)
    {
        Input = input;
    }

    public void SolvePartOne()
    {
        var almanac = new Almanac(Input);
        var locationIds = almanac.Seeds.Select(s => s.LocationId);

        Console.WriteLine($"Part One: {locationIds.Min()}\n");
    }

    public void SolvePartTwo()
    {
        var almanac = new Almanac(Input, true);
        var locationIds = almanac.Seeds.Select(s => s.LocationId);

        Console.WriteLine($"\nPart Two: {locationIds.Min()}");
    }
}
