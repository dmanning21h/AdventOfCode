using AdventOfCode.Lib;

namespace AdventOfCode.Y2024.Day05;

public sealed class Solution : ISolution
{
    private readonly string[] pageOrderingRules;
    private readonly string[] pageUpdates;

    public Solution(string rawInput)
    {
        var splitInput = rawInput.Split("\r\n\r\n");

        pageOrderingRules = InputParser.ParseLines(splitInput[0]);
        pageUpdates = InputParser.ParseLines(splitInput[1]);
    }

    public string SolvePartOne()
    {
        int answer = 0;

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;

        return answer.ToString();
    }
}
