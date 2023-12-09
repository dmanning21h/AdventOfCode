namespace Day03;

public sealed class Solution
{

    public static void SolvePartOne(EngineSchematic engineSchematic)
    {
        var answer = engineSchematic.SchematicLines.Sum(s => s.PartNumbers.Where(p => p.IsValid).Sum(p => p.Value));

        Console.WriteLine($"Part One: {answer}");
    }

    public static void SolvePartTwo(EngineSchematic engineSchematic)
    {
        var answer = engineSchematic.SchematicLines.Sum(s => s.Gears.Where(g => g.IsValid).Sum(g => g.GearRatio));

        Console.WriteLine($"Part Two: {answer}");
    }
}
