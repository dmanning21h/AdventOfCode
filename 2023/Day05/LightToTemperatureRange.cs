namespace Day05;

public class LightToTemperatureRange : BaseRange
{
    public long LightId => Range.SourceId;
    public long TemperatureId => Range.DestinationId;

    public LightToTemperatureRange(Range range) : base(range, "Light", "Temperature")
    {
    }
}
