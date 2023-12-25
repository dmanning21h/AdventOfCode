namespace Day05;

public interface IBaseRange
{
    public Range Range { get; set; }
    public long Length { get; }

    public IBaseRange FindOverlappingRange(List<IBaseRange> ranges);
    public bool Overlaps(IBaseRange previous);
    public void AdjustRange(IBaseRange previous);
}

public abstract class BaseRange
{
    public bool Contains(long id) => Range.Contains(id);
    public long GetDestinationId(long id) => Range.GetDestinationId(id);
    public long Length => Range.Length;

    public string SourceName { get; init; }
    public string DestinationName { get; init; }
    public Range Range { get; set; }

    public BaseRange(Range range, string sourceName, string destinationName)
    {
        Range = range;
        SourceName = sourceName;
        DestinationName = destinationName;
    }

    public Range FindOverlappingRange(IEnumerable<Range> ranges)
    {
        foreach (var range in ranges)
        {
            if (Overlaps(range))
            {
                return AdjustRange(range);
            }
        }
        return null;
    }

    public bool Overlaps(Range previous)
    {
        if (Range.SourceId >= previous.DestinationId && Range.SourceId <= previous.DestinationId + previous.Length - 1)
        {
            return true;
        }
        return false;
    }

    public Range AdjustRange(Range previous)
    {
        long startOffset = Range.SourceId - previous.DestinationId;

        long newPreviousDestinationStart = previous.DestinationId + startOffset;
        long newPreviousSourceStart = previous.SourceId + startOffset;

        // Trim the end of the range
        long currentEnd = Range.SourceId + Range.Length - 1;
        long previousEnd = previous.DestinationId + previous.Length - 1;
        // Take the lower of the two ranges and adjust the length
        long newEnd = Math.Min(currentEnd, previousEnd);
        long newLength = newEnd - newPreviousDestinationStart + 1;


        // Update previous range
        return new Range(newPreviousSourceStart, newPreviousDestinationStart, newLength);
    }

    public void PrintRange()
    {
        Console.WriteLine($"{SourceName}: {Range.SourceId} - {Range.SourceId + Length - 1}");
        Console.WriteLine($"{DestinationName}: {Range.DestinationId} - {Range.DestinationId + Length - 1}");
    }
}
