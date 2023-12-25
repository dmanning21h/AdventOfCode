namespace Day05;

public sealed class Almanac
{
    public List<Seed> Seeds { get; init; }
    public SeedToSoilRangeManager SeedToSoilRangeManager { get; init; }
    public SoilToFertilizerRangeManager SoilToFertilizerRangeManager { get; init; }
    public FertilizerToWaterRangeManager FertilizerToWaterRangeManager { get; init; }
    public WaterToLightRangeManager WaterToLightRangeManager { get; init; }
    public LightToTemperatureRangeManager LightToTemperatureRangeManager { get; init; }
    public TemperatureToHumidityRangeManager TemperatureToHumidityRangeManager { get; init; }
    public HumidityToLocationRangeManager HumidityToLocationRangeManager { get; init; }

    public Almanac(string input, bool isPartTwo = false)
    {
        var sections = input.Split("\n\n");
        var seedsInput = sections[0];
        var seedsToSoilInput = sections[1];
        var soilToFertilizerInput = sections[2];
        var fertilizerToWaterInput = sections[3];
        var waterToLightInput = sections[4];
        var lightToTemperatureInput = sections[5];
        var temperatureToHumidityInput = sections[6];
        var humidityToLocationInput = sections[7];

        SeedToSoilRangeManager = new SeedToSoilRangeManager(seedsToSoilInput);
        SoilToFertilizerRangeManager = new SoilToFertilizerRangeManager(soilToFertilizerInput);
        FertilizerToWaterRangeManager = new FertilizerToWaterRangeManager(fertilizerToWaterInput);
        WaterToLightRangeManager = new WaterToLightRangeManager(waterToLightInput);
        LightToTemperatureRangeManager = new LightToTemperatureRangeManager(lightToTemperatureInput);
        TemperatureToHumidityRangeManager = new TemperatureToHumidityRangeManager(temperatureToHumidityInput);
        HumidityToLocationRangeManager = new HumidityToLocationRangeManager(humidityToLocationInput);


        Seeds = ParseSeeds(seedsInput,
            isPartTwo);
    }

    private List<Seed> ParseSeeds(string seedsInput,
        bool isPartTwo
        )
    {
        var seeds = new List<Seed>();
        var seedIdData = new List<long>();
        var seedIds = new List<long>();


        var lines = seedsInput.Split(" ");
        for (int i = 1; i < lines.Length; i++)
        {
            seedIdData.Add(long.Parse(lines[i]));
        }

        if (isPartTwo)
        {
            var seedRangeManager = new SeedRangeManager(seedsInput);

            var seedRanges = seedRangeManager.PrintRanges;
            SeedToSoilRangeManager.PrintRanges();
            SoilToFertilizerRangeManager.PrintRanges();
            FertilizerToWaterRangeManager.PrintRanges();
            WaterToLightRangeManager.PrintRanges();
            LightToTemperatureRangeManager.PrintRanges();
            TemperatureToHumidityRangeManager.PrintRanges();
            HumidityToLocationRangeManager.PrintRanges();


            //for (int i = 0; i < seedRanges.Count; i++)
            //{
            //    var previousSeedRange = i == 0 ? null : seedRanges[i - 1];
            //    var seedRange = seedRanges[i];

            //    if (previousSeedRange != null && previousSeedRange.SeedId + previousSeedRange.Length != seedRange.SeedId)
            //    {
            //        Console.WriteLine($"Gap: {previousSeedRange.SeedId + previousSeedRange.Length} - {seedRange.SeedId - 1}");
            //    }

            //    seedRange.PrintRange();
            //}


            SeedRange lowestSeedRange;
            foreach (var humidityToLocationRange in HumidityToLocationRangeManager.HumidityToLocationRanges.OrderBy(l => l.LocationId))
            {
                Range range = humidityToLocationRange.FindOverlappingRange(TemperatureToHumidityRangeManager.TemperatureToHumidityRanges.Select(r => r.Range));
                var temperatureToHumidityRange = new TemperatureToHumidityRange(range);

                range = temperatureToHumidityRange.FindOverlappingRange(LightToTemperatureRangeManager.LightToTemperatureRanges.Select(r => r.Range));
                var lightToTemperatureRange = new LightToTemperatureRange(range);

                range = lightToTemperatureRange.FindOverlappingRange(WaterToLightRangeManager.WaterToLightRanges.Select(r => r.Range));
                var waterToLightRange = new WaterToLightRange(range);

                range = waterToLightRange.FindOverlappingRange(FertilizerToWaterRangeManager.FertilizerToWaterRanges.Select(r => r.Range));
                var fertilizerToWaterRange = new FertilizerToWaterRange(range);

                range = fertilizerToWaterRange.FindOverlappingRange(SoilToFertilizerRangeManager.SoilToFertilizerRanges.Select(r => r.Range));
                var soilToFertilizerRange = new SoilToFertilizerRange(range);

                range = soilToFertilizerRange.FindOverlappingRange(SeedToSoilRangeManager.SeedToSoils.Select(r => r.Range));
                var seedToSoilRange = new SeedToSoilRange(range);

                range = seedToSoilRange.FindOverlappingRange(seedRangeManager.SeedRanges.Select(r => r.Range));
                if (range != null)
                {
                    lowestSeedRange = new SeedRange(range);
                    Console.WriteLine($"Seed Range: {lowestSeedRange.SeedId} - {lowestSeedRange.SeedId + lowestSeedRange.Length - 1}");
                    break;
                }
            }

            //Console.WriteLine($"Location Range: {humidityToLocationRange.LocationId} - {humidityToLocationRange.LocationId + humidityToLocationRange.Length - 1}");
            //Console.WriteLine($"Humidity Range: {humidityToLocationRange.HumidityId} - {humidityToLocationRange.HumidityId + humidityToLocationRange.Length - 1}\n");

            //var temperatureToHumidityRangeRange = humidityToLocationRange.FindOverlappingRange(temperatureToHumidityRanges.Select(r => r.Range));
            //var temperatureToHumidityRange = new TemperatureToHumidityRange(temperatureToHumidityRangeRange);
            //Console.WriteLine($"Humidity Range: {temperatureToHumidityRange.HumidityId} - {temperatureToHumidityRange.HumidityId + temperatureToHumidityRange.Length - 1}");
            //Console.WriteLine($"Temperature Range: {temperatureToHumidityRange.TemperatureId} - {temperatureToHumidityRange.TemperatureId + temperatureToHumidityRange.Length - 1} \n");

            //var lightToTemperatureRangeRange = temperatureToHumidityRange.FindOverlappingRange(lightToTemperatureRanges.Select(r => r.Range));
            //var lightToTemperatureRange = new LightToTemperatureRange(lightToTemperatureRangeRange);
            //Console.WriteLine($"Temperature Range: {lightToTemperatureRange.TemperatureId} - {lightToTemperatureRange.TemperatureId + lightToTemperatureRange.Length - 1}");
            //Console.WriteLine($"Light Range: {lightToTemperatureRange.LightId} - {lightToTemperatureRange.LightId + lightToTemperatureRange.Length - 1} \n");

            //var waterToLightRangeRange = lightToTemperatureRange.FindOverlappingRange(waterToLightRanges.Select(r => r.Range));
            //var waterToLightRange = new WaterToLightRange(waterToLightRangeRange);
            //Console.WriteLine($"Light Range: {waterToLightRange.LightId} - {waterToLightRange.LightId + waterToLightRange.Length - 1}");
            //Console.WriteLine($"Water Range: {waterToLightRange.WaterId} - {waterToLightRange.WaterId + waterToLightRange.Length - 1} \n");

            //var fertilizerToWaterRangeRange = waterToLightRange.FindOverlappingRange(fertilizerToWaterRanges.Select(r => r.Range));
            //var fertilizerToWaterRange = new FertilizerToWaterRange(fertilizerToWaterRangeRange);
            //Console.WriteLine($"Water Range: {fertilizerToWaterRange.WaterId} - {fertilizerToWaterRange.WaterId + fertilizerToWaterRange.Length - 1}");
            //Console.WriteLine($"Fertilizer Range: {fertilizerToWaterRange.FertilizerId} - {fertilizerToWaterRange.FertilizerId + fertilizerToWaterRange.Length - 1} \n");

            //var soilToFertilizerRangeRange = fertilizerToWaterRange.FindOverlappingRange(soilToFertilizerRanges.Select(r => r.Range));
            //var soilToFertilizerRange = new SoilToFertilizerRange(soilToFertilizerRangeRange);
            //Console.WriteLine($"Fertilizer Range: {soilToFertilizerRange.FertilizerId} - {soilToFertilizerRange.FertilizerId + soilToFertilizerRange.Length - 1}");
            //Console.WriteLine($"Soil Range: {soilToFertilizerRange.SoilId} - {soilToFertilizerRange.SoilId + soilToFertilizerRange.Length - 1} \n");

            //var seedToSoilRangeRange = soilToFertilizerRange.FindOverlappingRange(seedToSoilRanges.Select(r => r.Range));
            //var seedToSoilRange = new SeedToSoilRange(seedToSoilRangeRange);
            //Console.WriteLine($"Soil Range: {seedToSoilRange.SoilId} - {seedToSoilRange.SoilId + seedToSoilRange.Length - 1}");
            //Console.WriteLine($"Seed Range: {seedToSoilRange.SeedId} - {seedToSoilRange.SeedId + seedToSoilRange.Length - 1} \n");

            //foreach (var seedRangex in seedRanges.OrderBy(l => l.SeedId))
            //{
            //    Console.WriteLine($"Seed Range: {seedRangex.SeedId} - {seedRangex.SeedId + seedRangex.Length - 1}");
            //}


            var seed = new Seed(2117125008,
                SeedToSoilRangeManager.SeedToSoils,
                SoilToFertilizerRangeManager.SoilToFertilizerRanges,
                FertilizerToWaterRangeManager.FertilizerToWaterRanges,
                WaterToLightRangeManager.WaterToLightRanges,
                LightToTemperatureRangeManager.LightToTemperatureRanges,
                TemperatureToHumidityRangeManager.TemperatureToHumidityRanges,
                HumidityToLocationRangeManager.HumidityToLocationRanges);
            seeds.Add(seed);
        }
        else
        {
            seedIds = seedIdData;
            foreach (var seedId in seedIds)
            {
                var seed = new Seed(seedId,
                    SeedToSoilRangeManager.SeedToSoils,
                    SoilToFertilizerRangeManager.SoilToFertilizerRanges,
                    FertilizerToWaterRangeManager.FertilizerToWaterRanges,
                    WaterToLightRangeManager.WaterToLightRanges,
                    LightToTemperatureRangeManager.LightToTemperatureRanges,
                    TemperatureToHumidityRangeManager.TemperatureToHumidityRanges,
                    HumidityToLocationRangeManager.HumidityToLocationRanges);
                seeds.Add(seed);
            }
        }

        return seeds;
    }
}
