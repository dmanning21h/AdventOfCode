﻿using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2024.Day01;

public sealed class Solution : LineInputSolution, ISolution
{
    private List<int> leftList;
    private List<int> rightList;

    public Solution(string rawInput) : base(rawInput)
    {
        leftList = [];
        rightList = [];
        foreach (string line in lines)
        {
            var split = line.Split("   ");

            leftList.Add(int.Parse(split[0]));
            rightList.Add(int.Parse(split[1]));
        }

        leftList.Sort();
        rightList.Sort();
    }

    public string SolvePartOne()
    {
        int answer = 0;
        for (int i = 0; i < leftList.Count; i++) {
            answer += Math.Abs(leftList[i] - rightList[i]);
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        foreach (int number in leftList)
        {
            var similarityScore = rightList.Count(i => i == number);
            answer += number * similarityScore;
        }

        return answer.ToString();
    }
}
