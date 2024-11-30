namespace AdventOfCode.Y2023.Day02;

public sealed class Solution
{
    private static string[] ParseInput(string input)
    {
        return input.Split("\n");
    }

    public static void SolvePartOne(string input)
    {
        int answer = 0;
        foreach (var line in ParseInput(input))
        {
            var game = new CubeGame(line);
            if (game.IsValidGame)
            {
                answer += game.Id;
            }
        }

        Console.WriteLine($"Part One: {answer}");
    }

    public static void SolvePartTwo(string input)
    {
        int answer = 0;
        foreach (var line in ParseInput(input))
        {
            var game = new CubeGame(line);
            answer += game.MaximumRedCubes * game.MaximumGreenCubes * game.MaximumBlueCubes;
        }

        Console.WriteLine($"Part Two: {answer}");
    }
}
