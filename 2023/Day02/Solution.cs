using AdventOfCode.Lib;

namespace AdventOfCode.Y2023.Day02;

public sealed class Solution : BaseSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    { }

    public string SolvePartOne()
    {
        int answer = 0;
        foreach (var line in input)
        {
            var game = new CubeGame(line);
            if (game.IsValidGame)
            {
                answer += game.Id;
            }
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        foreach (var line in input)
        {
            var game = new CubeGame(line);
            answer += game.MaximumRedCubes * game.MaximumGreenCubes * game.MaximumBlueCubes;
        }

        return answer.ToString();
    }
}
