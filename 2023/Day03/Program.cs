using AdventOfCode.Lib;

namespace AdventOfCode.Y2023.Day03;

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = "input.txt";

        var input = InputReader.ReadInput(filePath);

        var engineSchematic = new EngineSchematic(input);

        Solution.SolvePartOne(engineSchematic);
        Solution.SolvePartTwo(engineSchematic);
    }
}
