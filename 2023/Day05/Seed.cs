namespace Day05;

public class Seed
{
    public long SeedId { get; init; }
    public long SoilId { get; init; }
    public long FertilizerId { get; init; }
    public long WaterId { get; init; }
    public long LightId { get; init; }
    public long TemperatureId { get; init; }
    public long HumidityId { get; init; }
    public long LocationId { get; init; }

    public Seed(long id,
        List<SeedToSoilRange> seedToSoilRanges,
        List<SoilToFertilizerRange> soilToFertilizerRanges,
        List<FertilizerToWaterRange> fertilizerToWaterRanges,
        List<WaterToLightRange> waterToLightRanges,
        List<LightToTemperatureRange> lightToTemperatureRanges,
        List<TemperatureToHumidityRange> temperatureToHumidityRanges,
        List<HumidityToLocationRange> humidityToLocationRanges)
    {
        SeedId = id;
        SoilId = FindSoilId(id, seedToSoilRanges);
        FertilizerId = FindFertilizerId(SoilId, soilToFertilizerRanges);
        WaterId = FindWaterId(FertilizerId, fertilizerToWaterRanges);
        LightId = FindLightId(WaterId, waterToLightRanges);
        TemperatureId = FindTemperatureId(LightId, lightToTemperatureRanges);
        HumidityId = FindHumidityId(TemperatureId, temperatureToHumidityRanges);
        LocationId = FindLocationId(HumidityId, humidityToLocationRanges);
    }

    private long FindSoilId(long seedId, List<SeedToSoilRange> seedToSoilRanges)
    {
        return seedToSoilRanges.FirstOrDefault(r => r.Contains(seedId))?.GetDestinationId(seedId) ?? seedId;
    }

    private long FindFertilizerId(long soilId, List<SoilToFertilizerRange> soilToFertilizerRanges)
    {
        return soilToFertilizerRanges.FirstOrDefault(r => r.Contains(soilId))?.GetDestinationId(soilId) ?? soilId;
    }

    private long FindWaterId(long fertilizerId, List<FertilizerToWaterRange> fertilizerToWaterRanges)
    {
        return fertilizerToWaterRanges.FirstOrDefault(r => r.Contains(fertilizerId))?.GetDestinationId(fertilizerId) ?? fertilizerId;
    }

    private long FindLightId(long waterId, List<WaterToLightRange> waterToLightRanges)
    {
        return waterToLightRanges.FirstOrDefault(r => r.Contains(waterId))?.GetDestinationId(waterId) ?? waterId;
    }

    private long FindTemperatureId(long lightId, List<LightToTemperatureRange> lightToTemperatureRanges)
    {
        return lightToTemperatureRanges.FirstOrDefault(r => r.Contains(lightId))?.GetDestinationId(lightId) ?? lightId;
    }

    private long FindHumidityId(long temperatureId, List<TemperatureToHumidityRange> temperatureToHumidityRanges)
    {
        return temperatureToHumidityRanges.FirstOrDefault(r => r.Contains(temperatureId))?.GetDestinationId(temperatureId) ?? temperatureId;
    }

    private long FindLocationId(long humidityId, List<HumidityToLocationRange> humidityToLocationRanges)
    {
        return humidityToLocationRanges.FirstOrDefault(r => r.Contains(humidityId))?.GetDestinationId(humidityId) ?? humidityId;
    }
}
