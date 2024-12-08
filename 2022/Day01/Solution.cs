using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2022.Day01;

public sealed class Solution : ISolution
{
    private List<List<int>> elvesInputs;

    public Solution(string rawInput)
    {
        var groupedInput = rawInput.Split("\r\n\r\n");

        elvesInputs = [];
        for (int i = 0; i < groupedInput.Length; i++)
        {
            var calorieLines = groupedInput[i].Split('\n');
            List<int> caloriesHolding = [];
            foreach (var calorieLine in calorieLines)
            {
                caloriesHolding.Add(int.Parse(calorieLine));
            }

            elvesInputs.Add(caloriesHolding);
        }

        elvesInputs.Sort((a, b) => b.Sum().CompareTo(a.Sum()));
    }

    public string SolvePartOne()
    {
        int maxCalories = elvesInputs.First().Sum();

        return maxCalories.ToString();
    }

    public string SolvePartTwo()
    {
        var top3Calories = elvesInputs.Take(3).ToList();
        var totalCalories = top3Calories.Sum(calories => calories.Sum());

        return totalCalories.ToString();
    }
}
