using AdventOfCode.Lib;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2024.Day04;

public sealed class Solution : ISolution
{
    private readonly string[] rows;
    private readonly string[] columns;

    public Solution(string rawInput)
    {
        rows = InputParser.ParseLines(rawInput);
        columns = new string[rows[0].Length];
        for (int i = 0; i < rows[0].Length; i++)
        {
            columns[i] = new string(rows.Select(x => x[i]).ToArray());
        }
    }

    public string SolvePartOne()
    {
        int answer = 0;

        for (int i = 0; i < rows.Length - 3; i++)
        {
            for (int j = 0; j < columns.Length - 3; j++)
            {
                char[,] window = Get4x4Window(i, j);

                answer += GetDiagonalXMASCount(window);
            }
        }

        foreach (var row in rows)
        {
            answer += GetLineMatches(row);
        }

        foreach (var column in columns)
        {
            answer += GetLineMatches(column);
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;

        for (int i = 0; i < rows.Length - 2; i++)
        {
            for (int j = 0; j < columns.Length - 2; j++)
            {
                char[,] window = Get3x3Window(i, j);
                if (IsXMAS(window))
                {
                    answer++;
                }
            }
        }

        return answer.ToString();
    }

    private char[,] Get3x3Window(int startX, int startY)
    {
        char[,] window = new char[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                window[i, j] = rows[startX + i][startY + j];
            }
        }
        return window;
    }

    private static Regex masPattern = new Regex(@"MAS|SAM");

    private bool IsXMAS(char[,] window)
    {
        string forwardDiagonal = new string(new[] { window[0, 0], window[1, 1], window[2, 2] });
        string reverseDiagonal = new string(new[] { window[0, 2], window[1, 1], window[2, 0] });
        if (masPattern.IsMatch(forwardDiagonal) && masPattern.IsMatch(reverseDiagonal))
        {
            return true;
        }

        return false;
    }

    private char[,] Get4x4Window(int startX, int startY)
    {
        char[,] window = new char[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                window[i, j] = rows[startX + i][startY + j];
            }
        }
        return window;
    }

    private int GetDiagonalXMASCount(char[,] window)
    {
        int count = 0;

        string forwardDiagonal = new string(new[] { window[0, 0], window[1, 1], window[2, 2], window[3, 3] });
        count += GetLineMatches(forwardDiagonal);

        string reverseDiagonal = new string(new[] { window[0, 3], window[1, 2], window[2, 1], window[3, 0] });
        count += GetLineMatches(reverseDiagonal);

        return count;
    }

    private static Regex xmasPattern = new Regex(@"(?=XMAS|SAMX)");

    private int GetLineMatches(string line)
    {
        return xmasPattern.Matches(line).Count;
    }
}
