using System.Reflection;

namespace Day01
{
    public sealed class Day01Solution
    {
        public void Solve()
        {
            var input = GetInput();
            PartOne(input);
            PartTwo(input);
        }

        public void PartOne(string[] input)
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

        public void PartTwo(string[] input)
        {
            int sum = 0;
            foreach (var line in input)
            {
                int firstIndex = 1000;
                int lastIndex = -1;
                int firstValue = 0;
                int lastValue = 0;
                foreach (var key in NumberDictionary.Keys)
                {
                    if (line.Contains(key))
                    {
                        int index = line.IndexOf(key);
                        if (index > -1)
                        {
                            if (index < firstIndex)
                            {
                                firstIndex = index;
                                NumberDictionary.TryGetValue(key, out firstValue);
                            }
                            if (index > lastIndex)
                            {
                                lastIndex = index;
                                NumberDictionary.TryGetValue(key, out lastValue);
                            }

                            int nextIndex = line.IndexOf(key, index + 1);
                            if (nextIndex > -1)
                            {
                                if (nextIndex > lastIndex)
                                {
                                    lastIndex = nextIndex;
                                    NumberDictionary.TryGetValue(key, out lastValue);
                                }
                            }
                        }
                    }
                }

                int firstIntIndex = line.IndexOf(line.First(char.IsDigit));
                int lastIntIndex = line.IndexOf(line.Last(char.IsDigit));

                if (firstIntIndex < firstIndex)
                {
                    firstValue = int.Parse(line.First(char.IsDigit).ToString());
                }

                if (lastIntIndex > lastIndex)
                {
                    lastValue = int.Parse(line.Last(char.IsDigit).ToString());
                }

                Console.WriteLine(line);
                Console.WriteLine($"{firstValue} {lastValue}");

                sum += 10 * firstValue + lastValue;
            }

            Console.WriteLine(sum);
        }

        private string[] GetInput()
        {
            var executablePath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent.FullName;
            if (executablePath == null) throw new Exception("Could not find input file.");

            var filePath = Path.Combine(executablePath, "Day01/input.txt");
            return File.ReadAllLines(filePath);
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
}
