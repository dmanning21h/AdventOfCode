namespace Day05;

public class FertilizerToWaterRange : BaseRange
{
    public long FertilizerId => Range.SourceId;
    public long WaterId => Range.DestinationId;

    public FertilizerToWaterRange(Range range) : base(range, "Fertilizer", "Water")
    {
    }
}
