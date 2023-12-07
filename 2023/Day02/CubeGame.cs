namespace Day02;

public sealed class CubeGame
{
    public int Id { get; init; }
    public IEnumerable<CubeGameSet> Sets { get; init; }
    public bool IsValidGame => Sets.All(x => x.IsValidSet);

    public int MaximumRedCubes => Sets.Max(x => x.RedCubes);
    public int MaximumGreenCubes => Sets.Max(x => x.GreenCubes);
    public int MaximumBlueCubes => Sets.Max(x => x.BlueCubes);

    public CubeGame(string line)
    {
        Id = GetGameId(line);
        Sets = GetGameSets(line);
    }


    private int GetGameId(string line)
    {
        var id = line.Split(":")[0].Split(' ')[1];

        return int.Parse(id);
    }

    private string[] GetRawGameSets(string line)
    {
        return line.Split(":")[1].Trim().Split(';');
    }

    private IEnumerable<CubeGameSet> GetGameSets(string line)
    {
        var gameSets = new List<CubeGameSet>();

        var rawGameSets = GetRawGameSets(line);
        foreach (var rawGameSet in rawGameSets)
        {
            gameSets.Add(new CubeGameSet(rawGameSet));
        }

        return gameSets;
    }
}

public sealed class CubeGameSet
{
    public int RedCubes { get; init; }
    public int GreenCubes { get; init; }
    public int BlueCubes { get; init; }
    public bool IsValidSet => RedCubes <= 12 && GreenCubes <= 13 && BlueCubes <= 14;

    public CubeGameSet(string rawGameSet)
    {
        var cubeInputs = GetCubeInputs(rawGameSet);
        RedCubes = cubeInputs.FirstOrDefault(x => x.Color == "red")?.Count ?? 0;
        GreenCubes = cubeInputs.FirstOrDefault(x => x.Color == "green")?.Count ?? 0;
        BlueCubes = cubeInputs.FirstOrDefault(x => x.Color == "blue")?.Count ?? 0;
    }

    private IEnumerable<CubeInput> GetCubeInputs(string rawGameSet)
    {
        var cubeInputs = new List<CubeInput>();

        var rawCubeInputs = rawGameSet.Split(',');
        foreach (var rawCubeInput in rawCubeInputs)
        {
            cubeInputs.Add(new CubeInput(rawCubeInput.Trim()));
        }

        return cubeInputs;
    }
}

public sealed class CubeInput
{
    public string Color { get; init; }
    public int Count { get; init; }

    public CubeInput(string rawCubeInput)
    {
        var count = rawCubeInput.Split(' ')[0];
        var color = rawCubeInput.Split(' ')[1];

        Color = color;
        Count = int.Parse(count);
    }
}