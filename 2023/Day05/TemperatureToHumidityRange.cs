namespace Day05;

public class TemperatureToHumidityRange : BaseRange
{
    public long TemperatureId => Range.SourceId;
    public long HumidityId => Range.DestinationId;

    public TemperatureToHumidityRange(Range range) : base(range, "Temperature", "Humidity")
    {
    }
}