namespace AdventOfCode.Y2023.Day05;

public class SeedRange : BaseRange
{
    public long SeedId => Range.DestinationId;

    public SeedRange(Range range) : base(range, "Seed", "Seed")
    {
    }
}
