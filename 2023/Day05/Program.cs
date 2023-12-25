using Day05;

var filePath = "input.txt";
if (!File.Exists(filePath))
{
    Console.WriteLine($"Could not find input file at {filePath}");
}

var input = File.ReadAllText(filePath);

Solution Solution = new(input);

Solution.SolvePartOne();
Solution.SolvePartTwo();
