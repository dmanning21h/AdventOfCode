using AdventOfCode.Lib;

namespace AdventOfCode.Y2022.Day03;

public sealed class Solution : BaseSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    { }

    public string SolvePartOne()
    {
        int sum = 0;
        foreach (var line in input)
        {
            string firstHalf = line.Substring(0, line.Length / 2);
            string secondHalf = line.Substring(line.Length / 2);

            char duplicateChar = firstHalf.Intersect(secondHalf).First();

            sum += GetCharValue(duplicateChar);
        }

        return sum.ToString();
    }

    public string SolvePartTwo()
    {
        int sum = 0;
        for (int i = 0; i < input.Length - 2; i+=3)
        {
            var elfOne = input[i];
            var elfTwo = input[i + 1];
            var elfThree = input[i + 2];

            var badgeChar = elfOne.Intersect(elfTwo).Intersect(elfThree).First();
            sum += GetCharValue(badgeChar);
        }

        return sum.ToString();
    }

    public int GetCharValue(char c)
    {
        if (char.IsUpper(c))
        {
            return c - 'A' + 27;
        }
        else
        {
            return c - 'a' + 1;
        }
    }
}
