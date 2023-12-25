namespace Day05;

public static class RangeParser
{
    public static List<Range> ParseRanges(string rangeInput)
    {
        var ranges = new List<Range>();

        var input = rangeInput.Split("\n");
        for (int i = 1; i < input.Length; i++)
        {
            var line = input[i];
            var rangeData = line.Split(" ");
            var destinationStartId = long.Parse(rangeData[0]);
            var sourceStartId = long.Parse(rangeData[1]);
            var length = long.Parse(rangeData[2]);


            ranges.Add(new Range(sourceStartId, destinationStartId, length));
        }

        return ranges;
    }
}
