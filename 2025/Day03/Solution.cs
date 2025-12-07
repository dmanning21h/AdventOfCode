using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2025.Day03;

public sealed class Solution(string rawInput) : LineInputSolution(rawInput), ISolution
{
    public string SolvePartOne()
    {
        int answer = 0;

        foreach (string line in lines)
        {
            char maxValue = line[..^1].Max();
            int maxValueIndex = line.IndexOf(maxValue);

            char secondHighest = line[(maxValueIndex + 1)..].Max();

            int maxJoltage = int.Parse($"{maxValue}{secondHighest}");
            answer += maxJoltage;
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        long answer = 0;

        foreach (string line in lines)
        {
            string searchString = line;
            int remainingBatteries = 12;
            string maxJoltage = "";
            while (remainingBatteries > 0)
            {
                char maxValue = searchString[..^(remainingBatteries - 1)].Max();
                int maxValueIndex = searchString.IndexOf(maxValue);

                maxJoltage += maxValue;
                searchString = searchString[(maxValueIndex + 1)..];
                remainingBatteries--;
            }

            answer += long.Parse(maxJoltage);
        }

        return answer.ToString();
    }
}
