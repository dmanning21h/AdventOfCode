namespace Day05;

public abstract class BaseRangeManager
{
    public List<BaseRange> Ranges { get; set; }

    public BaseRangeManager(string input)
    {
        Ranges = ParseRanges(input);
    }

    public abstract BaseRange CreateRange(Range range);

    public void PrintRanges()
    {
        Console.WriteLine($"\n{Ranges.First().GetType().Name} Ranges:");

        for (int i = 0; i < Ranges.Count; i++)
        {
            var previousRange = i == 0 ? null : Ranges[i - 1];
            var currentRange = Ranges[i];

            // Previous range exists and there is a gap between the previous range and the current range
            if (previousRange != null && previousRange.Range.SourceId + previousRange.Length != currentRange.Range.SourceId)
            {
                Console.WriteLine($"Gap: {previousRange.Range.SourceId + previousRange.Length} - {currentRange.Range.SourceId - 1}");
            }
            // Previous range doesn't exist and the current range doesn't start at 0
            else if (previousRange == null && currentRange.Range.SourceId != 0)
            {
                Console.WriteLine($"Gap: 0 - {currentRange.Range.SourceId - 1}");
            }

            currentRange.PrintRange();
        }
    }

    protected virtual List<BaseRange> ParseRanges(string input)
    {
        return RangeParser.ParseRanges(input).Select(CreateRange).ToList();
    }
}
