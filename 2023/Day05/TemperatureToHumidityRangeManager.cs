namespace Day05;

public class TemperatureToHumidityRangeManager : BaseRangeManager
{
    public List<TemperatureToHumidityRange> TemperatureToHumidityRanges => Ranges.Select(r => (TemperatureToHumidityRange)r).ToList();

    public TemperatureToHumidityRangeManager(string temperatureToHumidityInput) : base(temperatureToHumidityInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new TemperatureToHumidityRange(range);
    }
}