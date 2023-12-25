namespace Day05;

public class HumidityToLocationRangeManager : BaseRangeManager
{
    public List<HumidityToLocationRange> HumidityToLocationRanges => Ranges.Select(r => (HumidityToLocationRange)r).ToList();

    public HumidityToLocationRangeManager(string humidityToLocationInput) : base(humidityToLocationInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new HumidityToLocationRange(range);
    }
}