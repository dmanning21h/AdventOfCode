namespace AdventOfCode.Lib.Input;

public static class InputReader
{
    public static string ReadRawInput(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find input file at {filePath}");
        }

        return File.ReadAllText(filePath);
    }
}
