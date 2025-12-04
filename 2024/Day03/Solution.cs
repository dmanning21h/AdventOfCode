using AdventOfCode.Lib.Solutions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2024.Day03;

public sealed class Solution : ISolution
{
    private readonly string input;

    public Solution(string rawInput)
    {
        input = rawInput;
    }

    public string SolvePartOne()
    {

        return GetSum(input).ToString();
    }

    public string SolvePartTwo()
    {
        var firstMatch = Regex.Match(input, @"(.*?)don't[()]");

        // Find the next match from this index
        int startIndex = firstMatch.Index + firstMatch.Length;

        int sum = GetSum(firstMatch.Groups[1].Value);

        int matchesCount = 0;
        while (startIndex < input.Length)
        {
            var match = Regex.Match(input.Substring(startIndex), @"do[()](.*?)don't[()]");
            if (!match.Success)
            {
                break;
            }
            matchesCount++;

            var text = match.Groups[1].Value;
            sum += GetSum(text);

            // Update startIndex to the end of the current match
            startIndex += match.Index + match.Length;
        }

        // Check for remaining text after the last match
        var remainingTextMatch = Regex.Match(input.Substring(startIndex), @"do[()](.*)");
        if (remainingTextMatch.Success)
        {
            var remainingText = remainingTextMatch.Groups[1].Value;
            sum += GetSum(remainingText);
        }

        return sum.ToString();
    }

    private int GetSum(string text)
    {
        Regex pattern = new(@"mul[(](?<value1>\d+),(?<value2>\d+)[)]");
        var match = pattern.Matches(text);

        int sum = 0;
        foreach (Match m in match)
        {
            var value1 = int.Parse(m.Groups["value1"].Value);
            var value2 = int.Parse(m.Groups["value2"].Value);

            sum += value1 * value2;
        }

        return sum;
    }
}
