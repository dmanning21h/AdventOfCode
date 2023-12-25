namespace Day05;

public class SeedToSoilRange : BaseRange
{
    public long SeedId => Range.SourceId;
    public long SoilId => Range.DestinationId;

    public SeedToSoilRange(Range range) : base(range, "Seed", "Soil")
    {
    }
}
