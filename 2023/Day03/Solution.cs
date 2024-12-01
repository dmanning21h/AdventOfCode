namespace AdventOfCode.Y2023.Day03;

public sealed class Solution
{
    private EngineSchematic engineSchematic;

    public Solution(string rawInput)
    {
        engineSchematic = new EngineSchematic(rawInput);
    }

    public string SolvePartOne()
    {
        var answer = engineSchematic.SchematicLines.Sum(s => s.PartNumbers.Where(p => p.IsValid).Sum(p => p.Value));

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        var answer = engineSchematic.SchematicLines.Sum(s => s.Gears.Where(g => g.IsValid).Sum(g => g.GearRatio));

        return answer.ToString();
    }
}
