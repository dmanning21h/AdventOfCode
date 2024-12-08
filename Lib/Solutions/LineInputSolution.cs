using AdventOfCode.Lib.Input;

namespace AdventOfCode.Lib.Solutions;

public abstract class LineInputSolution
{
    protected readonly string[] lines;

    protected LineInputSolution(string rawInput)
    {
        lines = InputParser.ParseLines(rawInput);
    }
}
