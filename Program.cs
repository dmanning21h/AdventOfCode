using AdventOfCode.Lib.Input;
using AdventOfCode.Lib.Solutions;
using System.Reflection;

namespace AdventOfCode;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var (year, day) = ParseArguments(args);
            var rawInput = ReadInput(year, day);

            var solutionTypeName = $"AdventOfCode.Y{year}.Day{day:D2}.Solution";
            var solutionType = Assembly.GetExecutingAssembly().GetType(solutionTypeName);

            if (solutionType == null)
            {
                Console.WriteLine($"Solution class not found for year {year} and day {day}.");
                return;
            }

            if (Activator.CreateInstance(solutionType, rawInput) is not ISolution solution)
            {
                Console.WriteLine($"Failed to create an instance of {solutionTypeName}.");
                return;
            }

            Console.WriteLine($"Part One: {solution.SolvePartOne()}");
            Console.WriteLine($"Part Two: {solution.SolvePartTwo()}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static (int year, int day) ParseArguments(string[] args)
    {
        var year = 0;
        var day = 0;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--year" && i + 1 < args.Length)
            {
                year = int.Parse(args[i + 1]);
            }
            else if (args[i] == "--day" && i + 1 < args.Length)
            {
                day = int.Parse(args[i + 1]);
            }
        }

        if (year == 0)
        {
            throw new ArgumentException("Please provide the year value using --year argument.");
        }

        if (day == 0)
        {
            Console.Write("Please enter the day: ");
            if (!int.TryParse(Console.ReadLine(), out day))
            {
                throw new ArgumentException("Invalid day value.");
            }
        }

        var currentDate = DateTime.Now;
        if (year > currentDate.Year || (year == currentDate.Year && day > 25))
        {
            throw new ArgumentException("The provided date is in the future.");
        }

        if (day < 1 || day > 25)
        {
            throw new ArgumentException("Day value must be between 1 and 25.");
        }

        return (year, day);
    }

    private static string ReadInput(int year, int day)
    {
        var inputFilename = $"{year}/Day{day:D2}/input.txt";
        if (!File.Exists(inputFilename))
        {
            throw new FileNotFoundException($"Input file not found: {inputFilename}");
        }

        return InputReader.ReadRawInput(inputFilename);
    }
}
