namespace AdventOfCode.Lib;

public abstract class BaseSolution
{
    protected readonly string[] input;

    protected BaseSolution(string rawInput)
    {
        input = InputParser.ParseLines(rawInput);
    }
}
