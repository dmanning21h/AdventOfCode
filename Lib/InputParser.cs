namespace AdventOfCode.Lib;

public static class InputParser
{
    public static string[] ParseLines(string rawInput)
    {
        return rawInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
    }
}
