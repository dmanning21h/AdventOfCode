using AdventOfCode.Lib.Solutions;
using System.Text;

namespace AdventOfCode.Y2024.Day07;

public sealed class Solution : LineInputSolution, ISolution
{
    private readonly List<Equation> equations;

    public Solution(string rawInput) : base(rawInput)
    {
        equations = [];
        foreach (var line in lines)
        {
            var parts = line.Split(":");
            var testValue = long.Parse(parts[0]);
            var equationNumbers = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            equations.Add(new Equation(testValue, equationNumbers));
        }
    }

    public string SolvePartOne()
    {
        long answer = 0;
        foreach (var equation in equations)
        {
            if (CanSolveEquation(equation, ['+', '*']))
            {
                answer += equation.TestValue;
            }
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        long answer = 0;
        foreach (var equation in equations)
        {
            if (CanSolveEquation(equation, ['+', '*', '|']))
            {
                answer += equation.TestValue;
            }
        }

        return answer.ToString();
    }

    private bool CanSolveEquation(Equation equation, char[] operands)
    {
        var combinations = CombinationGenerator.GenerateCombinations(operands, equation.EquationNumbers.Count - 1);
        var equationNumbers = equation.EquationNumbers.ToList();

        foreach (var combination in combinations)
        {
            long runningTotal = 0;
            for (int i = 0; i < combination.Length; i++)
            {
                if (i == 0)
                {
                    runningTotal = equationNumbers[i];
                }

                if (combination[i] == '+')
                {
                    runningTotal += equationNumbers[i + 1];
                }
                else if (combination[i] == '*')
                {
                    runningTotal *= equationNumbers[i + 1];
                }
                else
                {
                    runningTotal = long.Parse($"{runningTotal}{equationNumbers[i + 1]}");
                }

                if (runningTotal > equation.TestValue)
                {
                    break;
                }
            }

            if (runningTotal == equation.TestValue)
            {
                return true;
            }
        }

        return false;
    }

    private sealed class Equation
    {
        public long TestValue { get; init; }

        public List<int> EquationNumbers { get; init; }

        public Equation(long testValue, List<int> equationNumbers)
        {
            TestValue = testValue;
            EquationNumbers = equationNumbers;
        }
    }

    private class CombinationGenerator
    {
        public static List<string> GenerateCombinations(char[] chars, int length)
        {
            var result = new List<string>();
            GenerateCombinationsRecursive(chars, length, new StringBuilder(), result);
            return result;
        }

        private static void GenerateCombinationsRecursive(char[] chars, int length, StringBuilder current, List<string> result)
        {
            if (current.Length == length)
            {
                result.Add(current.ToString());
                return;
            }

            foreach (var c in chars)
            {
                current.Append(c);
                GenerateCombinationsRecursive(chars, length, current, result);
                current.Length--;
            }
        }
    }
}
