namespace Day05;

public class SeedToSoilRangeManager : BaseRangeManager
{
    public List<SeedToSoilRange> SeedToSoils => Ranges.Select(r => (SeedToSoilRange)r).ToList();

    public SeedToSoilRangeManager(string seedToSoilInput) : base(seedToSoilInput)
    {
    }

    public override BaseRange CreateRange(Range range)
    {
        return new SeedToSoilRange(range);
    }
}
