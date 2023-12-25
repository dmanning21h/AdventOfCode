using Day04;

var filePath = "input.txt";
if (!File.Exists(filePath))
{
    Console.WriteLine($"Could not find input file at {filePath}");
}

var input = File.ReadAllLines(filePath);

Solution Solution = new(input);

Solution.SolvePartOne();
Solution.SolvePartTwo();
