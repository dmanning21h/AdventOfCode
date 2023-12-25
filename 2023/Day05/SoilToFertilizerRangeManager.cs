namespace Day05;

public class SoilToFertilizerRangeManager : BaseRangeManager
{
    public List<SoilToFertilizerRange> SoilToFertilizerRanges => Ranges.Select(r => (SoilToFertilizerRange)r).ToList();

    public SoilToFertilizerRangeManager(string soilToFertilizerInput) : base(soilToFertilizerInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new SoilToFertilizerRange(range);
    }
}
