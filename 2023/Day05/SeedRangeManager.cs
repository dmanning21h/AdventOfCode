namespace Day05;

public class SeedRangeManager : BaseRangeManager
{
    public List<SeedRange> SeedRanges => Ranges.Select(r => (SeedRange)r).ToList();

    public SeedRangeManager(string seedInput) : base(seedInput)
    {

    }

    public override BaseRange CreateRange(Range range)
    {
        return new SeedRange(range);
    }

    protected override List<BaseRange> ParseRanges(string seedInput)
    {
        var seedIdData = new List<long>();
        var lines = seedInput.Split(" ");
        for (int i = 1; i < lines.Length; i++)
        {
            seedIdData.Add(long.Parse(lines[i]));
        }

        var seedRanges = new List<BaseRange>();
        for (int i = 0; i < seedIdData.Count(); i += 2)
        {
            seedRanges.Add(CreateRange(new Range(seedIdData[i], seedIdData[i], seedIdData[i + 1])));
        }

        return seedRanges;
    }
}
