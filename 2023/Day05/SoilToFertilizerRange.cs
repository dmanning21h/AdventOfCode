namespace Day05;

public class SoilToFertilizerRange : BaseRange
{
    public long SoilId => Range.SourceId;
    public long FertilizerId => Range.DestinationId;

    public SoilToFertilizerRange(Range range) : base(range, "Soil", "Fertilizer")
    {
    }
}
