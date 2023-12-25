namespace Day05;

public sealed class Range
{
    public long SourceId { get; init; }
    public long DestinationId { get; init; }
    public long Length { get; init; }

    public Range(long sourceId, long destinationId, long length)
    {
        SourceId = sourceId;
        DestinationId = destinationId;
        Length = length;
    }

    public bool Contains(long id)
    {
        return SourceId <= id && id < SourceId + Length;
    }

    public long GetDestinationId(long id)
    {
        var offset = id - SourceId;

        return DestinationId + offset;
    }
}
