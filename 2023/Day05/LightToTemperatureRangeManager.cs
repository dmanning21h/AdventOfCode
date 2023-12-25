namespace Day05;

public class LightToTemperatureRangeManager : BaseRangeManager
{
    public List<LightToTemperatureRange> LightToTemperatureRanges => Ranges.Select(r => (LightToTemperatureRange)r).ToList();

    public LightToTemperatureRangeManager(string lightToTemperatureInput) : base(lightToTemperatureInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new LightToTemperatureRange(range);
    }
}
