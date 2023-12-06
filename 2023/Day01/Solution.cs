namespace Day01;

public sealed class Solution
{

    public static void SolvePartOne(string[] input)
    {
        int sum = 0;
        int first, second;

        foreach (var line in input)
        {
            first = int.Parse(line.First(char.IsDigit).ToString());
            second = int.Parse(line.Last(char.IsDigit).ToString());
            sum += 10 * first + second;
        }

        Console.WriteLine(sum);
    }

    public static void SolvePartTwo(string[] input)
    {
        int sum = 0;
        foreach (var line in input)
        {
            int firstValue = GetFirstDigit(line);
            int lastValue = GetLastDigit(line);

            Console.WriteLine(line);
            Console.WriteLine($"{firstValue} {lastValue}");

            sum += 10 * firstValue + lastValue;
        }

        Console.WriteLine(sum);
    }

    private static int GetFirstDigit(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i] - '0';
            }
            else
            {
                foreach (var key in NumberDictionary.Keys)
                {
                    if (i + key.Length > line.Length)
                    {
                        continue;
                    }
                    if (line.Substring(i, key.Length).Equals(key))
                    {
                        NumberDictionary.TryGetValue(key, out int value);
                        return value;
                    }
                }
            }
        }
        return 0;
    }

    private static int GetLastDigit(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i] - '0';
            }
            else
            {
                foreach (var key in NumberDictionary.Keys)
                {
                    if (i + key.Length > line.Length)
                    {
                        continue;
                    }
                    if (line.Substring(i, key.Length).Equals(key))
                    {
                        NumberDictionary.TryGetValue(key, out int value);
                        return value;
                    }
                }
            }
        }
        return 0;
    }

    private static Dictionary<string, int> NumberDictionary = new Dictionary<string, int>
    {
        {"one", 1 },
        {"two", 2},
        {"three",3 },
        {"four", 4},
        {"five", 5},
        {"six", 6 },
        {"seven", 7 },
        {"eight", 8 },
        {"nine", 9 },
    };
}
