using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2025.Day01;

public sealed class Solution(string rawInput) : LineInputSolution(rawInput), ISolution
{
    public string SolvePartOne()
    {
        int answer = 0;

        int dialValue = 50;
        foreach (string line in lines)
        {
            char direction = line[0];
            int distance = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                distance *= -1;
            }

            dialValue += distance;
            dialValue = dialValue % 100;

            if (dialValue == 0)
            {
                answer++;
            }
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;

        int dialValue = 50;
        foreach (string line in lines)
        {
            char direction = line[0];
            int magnitude = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                magnitude *= -1;
            }

            if (magnitude > 0)
            {
                while (magnitude != 0)
                {
                    dialValue++;
                    magnitude--;
                    if (IsDialValueZero(dialValue))
                    {
                        answer++;
                    }
                }
            }
            else
            {
                while (magnitude != 0)
                {
                    dialValue--;
                    magnitude++;
                    if (IsDialValueZero(dialValue))
                    {
                        answer++;
                    }
                }
            }
        }

        return answer.ToString();
    }

    private static bool IsDialValueZero(int value) => (value == 0) || (value % 100 == 0);
}
