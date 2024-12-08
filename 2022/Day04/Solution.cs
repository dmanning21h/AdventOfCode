using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2022.Day04;

public sealed class Solution : LineInputSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    { }

    public string SolvePartOne()
    {
        int count = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var range1 = parts[0].Split('-');
            var range2 = parts[1].Split('-');
            var start1 = int.Parse(range1[0]);
            var end1 = int.Parse(range1[1]);
            var start2 = int.Parse(range2[0]);
            var end2 = int.Parse(range2[1]);
            if (EitherRangeContainsTheOther(start1, end1, start2, end2))
            {
                count++;
            }
        }

        return count.ToString();
    }

    public string SolvePartTwo()
    {
        int count = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var range1 = parts[0].Split('-');
            var range2 = parts[1].Split('-');
            var start1 = int.Parse(range1[0]);
            var end1 = int.Parse(range1[1]);
            var start2 = int.Parse(range2[0]);
            var end2 = int.Parse(range2[1]);
            if (EitherRangeOverlap(start1, end1, start2, end2))
            {
                count++;
            }
        }
        return count.ToString();
    }

    public bool EitherRangeContainsTheOther(int start1, int end1, int start2, int end2)
    {
        return (start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1);
    }

    public bool EitherRangeOverlap(int start1, int end1, int start2, int end2)
    {
        return (start1 >= start2 && start1 <= end2) ||
            (end1 >= start2 && end1 <= end2) ||
            (start2 >= start1 && start2 <= end1) ||
            (end2 >= start1 && (end2 <= end1));
    }
}
