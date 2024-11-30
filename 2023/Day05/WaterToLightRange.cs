namespace AdventOfCode.Y2023.Day05;

public class WaterToLightRange : BaseRange
{
    public long WaterId => Range.SourceId;
    public long LightId => Range.DestinationId;

    public WaterToLightRange(Range range) : base(range, "Water", "Light")
    {
    }
}
