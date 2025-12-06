using AdventOfCode.Lib.Geometry;
using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2015.Day03;

public sealed class Solution : ISolution
{
    private readonly string input;

    public Solution(string rawInput)
    {
        input = rawInput;
    }

    public string SolvePartOne()
    {
        (int santaX, int santaY) = (0, 0);
        HashSet<(int x, int y)> visitedHashes = [];

        visitedHashes.Add((santaX, santaY));
        foreach (char value in input)
        {
            (santaX, santaY) = ProcessInputMove(santaX, santaY, value);
            visitedHashes.Add((santaX, santaY));
        }

        return visitedHashes.Count.ToString();
    }

    public string SolvePartTwo()
    {
        (int santaX, int santaY) = (0, 0);
        (int roboSantaX, int roboSantaY) = (0, 0);
        HashSet<(int x, int y)> visitedHashes = [];
        
        visitedHashes.Add((santaX, santaY));
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                (santaX, santaY) = ProcessInputMove(santaX, santaY, input[i]);
                visitedHashes.Add((santaX, santaY));
            }
            else
            {
                (roboSantaX, roboSantaY) = ProcessInputMove(roboSantaX, roboSantaY, input[i]);
                visitedHashes.Add((roboSantaX, roboSantaY));
            }
        }

        return visitedHashes.Count.ToString();
    }

    public (int, int) ProcessInputMove(int x, int y, char value)
    {

        _ = value switch
        {
            '^' => y++,
            'v' => y--,
            '>' => x++,
            '<' => x--,
            _ => throw new InvalidDataException($"Invalid char {value}")
        };

        return (x, y);
    }
}
