namespace Day05;

public class WaterToLightRangeManager : BaseRangeManager
{
    public List<WaterToLightRange> WaterToLightRanges => Ranges.Select(r => (WaterToLightRange)r).ToList();

    public WaterToLightRangeManager(string waterToLightInput) : base(waterToLightInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new WaterToLightRange(range);
    }
}
