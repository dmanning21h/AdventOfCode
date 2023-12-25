namespace Day05;

public class HumidityToLocationRange : BaseRange
{
    public long HumidityId => Range.SourceId;
    public long LocationId => Range.DestinationId;

    public HumidityToLocationRange(Range range) : base(range, "Humidity", "Location")
    {
    }
}