namespace Day05;

public class FertilizerToWaterRangeManager : BaseRangeManager
{
    public List<FertilizerToWaterRange> FertilizerToWaterRanges => Ranges.Select(r => (FertilizerToWaterRange)r).ToList();

    public FertilizerToWaterRangeManager(string fertilizerToWaterInput) : base(fertilizerToWaterInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new FertilizerToWaterRange(range);
    }
}
