using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2015.Day01;

public sealed class Solution : ISolution
{
    private readonly string input;

    public Solution(string rawInput)
    {
        input = rawInput;
    }

    public string SolvePartOne()
    {
        int answer = 0;

        int openParenthesis = input.Count(c => c == '(');
        int closeParenthesis = input.Count(c => c == ')');

        answer = openParenthesis - closeParenthesis;

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        
        int runningTotal = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                runningTotal++;
            }
            else
            {
                runningTotal--;
            }

            if (runningTotal == -1)
            {
                answer = i + 1;
                break;
            }
        }

        return answer.ToString();
    }
}
