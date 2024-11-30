using AdventOfCode.Lib;

namespace AdventOfCode.Y2023.Day02;

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = "input.txt";

        var input = InputReader.ReadInput(filePath);

        Solution.SolvePartOne(input);
        Solution.SolvePartTwo(input);
    }
}
