using AdventOfCode.Lib.Input;
using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2025.Day02;

public sealed class Solution(string rawInput) : ISolution
{
    private readonly string[] _idRanges = InputParser.ParseLines(rawInput, ',');

    public string SolvePartOne()
    {
        long answer = 0;

        foreach (string idRange in _idRanges)
        {
            string startIndex = idRange.Split('-')[0];
            string endIndex = idRange.Split('-')[1];

            for (long i = long.Parse(startIndex); i <= long.Parse(endIndex); i++)
            {
                string id = i.ToString();

                if (id.Length % 2 == 0)
                {
                    int halfLength = id.Length / 2;
                    string firstHalf = id[0..halfLength];
                    string secondHalf = id[halfLength..];
                    if (firstHalf.Equals(secondHalf))
                    {
                        answer += long.Parse(id);
                    }
                }
            }
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        long answer = 0;
        HashSet<long> invalidIds = [];

        foreach (string idRange in _idRanges)
        {
            string startIndex = idRange.Split('-')[0];
            string endIndex = idRange.Split('-')[1];

            for (long i = long.Parse(startIndex); i <= long.Parse(endIndex); i++)
            {
                string id = i.ToString();
                for (int sequenceLength = 1; sequenceLength <= id.Length / 2; sequenceLength++)
                {
                    if (id.Length % sequenceLength == 0)
                    {
                        int sequenceCount = id.Length / sequenceLength;
                        Range[] ranges = new Range[sequenceCount];
                        for (int rangeId = 0; rangeId < sequenceCount; rangeId++)
                        {
                            ranges[rangeId] = (rangeId * sequenceLength)..((rangeId + 1) * sequenceLength);
                        }

                        string[] substrings = [.. ranges.Select(r => id[r])];
                        string firstSubstring = substrings[0];

                        if (substrings.All(s => s.Equals(firstSubstring)))
                        {
                            invalidIds.Add(long.Parse(id));
                        }
                    }
                }
            }
        }

        answer = invalidIds.Sum(s => s);
        return answer.ToString();
    }
}
