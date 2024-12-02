using AdventOfCode.Lib;

namespace AdventOfCode.Y2024.Day02;

public sealed class Solution : BaseSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    {
    }

    public string SolvePartOne()
    {
        int safeReportCount = 0;
        foreach (string line in input)
        {
            List<int> report = line.Split(' ').Select(int.Parse).ToList();

            if (IsReportValid(report))
            {
                safeReportCount++;
            }
        }

        return safeReportCount.ToString();
    }

    public string SolvePartTwo()
    {
        int safeReportCount = 0;
        foreach (string line in input)
        {
            List<int> report = line.Split(' ').Select(int.Parse).ToList();

            if (IsReportValidV2(report))
            {
                safeReportCount++;
            }
        }

        return safeReportCount.ToString();
    }

    private bool IsReportValid(List<int> report)
    {
        var adjacentErrorIndexes = FindAdjacentErrorIndices(report);
        var ascendingErrorIndexes = FindAscendingErrorIndices(report);
        var descendingErrorIndexes = FindDescendingErrorIndices(report);

        if ((ascendingErrorIndexes.Count > 0 && descendingErrorIndexes.Count > 0) || adjacentErrorIndexes.Count > 0)
        {
            return false;
        }

        return true;
    }

    private bool IsReportValidV2(List<int> report)
    {
        var adjacentErrorIndexes = FindAdjacentErrorIndices(report);
        var ascendingErrorIndexes = FindAscendingErrorIndices(report);
        var descendingErrorIndexes = FindDescendingErrorIndices(report);

        ascendingErrorIndexes.AddRange(adjacentErrorIndexes);
        descendingErrorIndexes.AddRange(adjacentErrorIndexes);

        foreach(var errorIndex in ascendingErrorIndexes.Distinct())
        {
            var reportCopy = new List<int>(report);
            reportCopy.RemoveAt(errorIndex);
            if (IsReportValid(reportCopy))
            {
                return true;
            }
        }

        foreach (var errorIndex in descendingErrorIndexes.Distinct())
        {
            var reportCopy = new List<int>(report);
            reportCopy.RemoveAt(errorIndex);
            if (IsReportValid(reportCopy))
            {
                return true;
            }
        }

        return false;
    }

    private List<int> FindAscendingErrorIndices(List<int> report)
    {
        List<int> errorIndexes = [];
        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
            {
                if (report[i] > report[i + 1])
                {
                    errorIndexes.Add(i);
                }
            }
            else if (i == report.Count - 1)
            {
                if (report[i - 1] > report[i])
                {
                    errorIndexes.Add(i);
                }
            }
            else
            {
                if (report[i - 1] > report[i] || report[i] > report[i + 1])
                {
                    errorIndexes.Add(i);
                }
            }
        }

        return errorIndexes;
    }

    private List<int> FindDescendingErrorIndices(List<int> report)
    {
        List<int> errorIndexes = [];
        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
            {
                if (report[i] < report[i + 1])
                {
                    errorIndexes.Add(i);
                }
            }
            else if (i == report.Count - 1)
            {
                if (report[i - 1] < report[i])
                {
                    errorIndexes.Add(i);
                }
            }
            else
            {
                if (report[i - 1] < report[i] || report[i] < report[i + 1])
                {
                    errorIndexes.Add(i);
                }
            }
        }

        return errorIndexes;
    }

    private List<int> FindAdjacentErrorIndices(List<int> report)
    {
        List<int> errorIndexes = [];
        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
            {
                var absDiff = Math.Abs(report[i] - report[i + 1]);
                if (absDiff < 1 || absDiff > 3)
                {
                    errorIndexes.Add(i);
                }
            }
            else if (i == report.Count - 1)
            {
                var absDiff = Math.Abs(report[i - 1] - report[i]);
                if (absDiff < 1 || absDiff > 3)
                {
                    errorIndexes.Add(i);
                }
            }
            else
            {
                var absDiff1 = Math.Abs(report[i - 1] - report[i]);
                var absDiff2 = Math.Abs(report[i] - report[i + 1]);
                if (absDiff1 < 1 || absDiff1 > 3 || absDiff2 < 1 || absDiff2 > 3)
                {
                    errorIndexes.Add(i);
                }
            }
        }

        return errorIndexes;
    }
}
