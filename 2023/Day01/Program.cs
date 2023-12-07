namespace Day01;

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = "input.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Could not find input file at {filePath}");
        }

        var input = File.ReadAllLines(filePath);

        Solution.SolvePartOne(input);
        Solution.SolvePartTwo(input);
    }
}
