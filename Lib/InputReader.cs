namespace AdventOfCode.Lib;

public static class InputReader
{
    public static string ReadInput(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find input file at {filePath}");
        }

        return File.ReadAllText(filePath);
    }
}
