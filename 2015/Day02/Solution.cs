using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2015.Day02;

public sealed class Solution : LineInputSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    { }

    public string SolvePartOne()
    {
        int answer = 0;
        foreach (string line in lines)
        {
            var dimensions = line.Split('x').Select(int.Parse).ToArray();
            int l = dimensions[0];
            int w = dimensions[1];
            int h = dimensions[2];

            answer += 2*l*w + 2*w*h + 2*h*l + Math.Min(l * w, Math.Min(w * h, h * l));
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        foreach (string line in lines)
        {
            var dimensions = line.Split('x').Select(int.Parse).ToArray();
            int l = dimensions[0];
            int w = dimensions[1];
            int h = dimensions[2];

            answer += (l * w * h) + Math.Min(2*l + 2*w, Math.Min(2*w + 2*h, 2*h + 2*l));
        }

        return answer.ToString();
    }
}
