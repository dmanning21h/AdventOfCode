namespace Day02;

public sealed class Solution
{

    public static void SolvePartOne(string[] input)
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

        Console.WriteLine($"Part One: {answer}");
    }

    public static void SolvePartTwo(string[] input)
    {
        int answer = 0;

        foreach (var line in input)
        {
            var game = new CubeGame(line);
            answer += game.MaximumRedCubes * game.MaximumGreenCubes * game.MaximumBlueCubes;
        }

        Console.WriteLine($"Part Two: {answer}");
    }
}
