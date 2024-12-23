﻿using AdventOfCode.Lib.Input;
using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2024.Day05;

public sealed class Solution : ISolution
{
    private readonly PageOrderRuleCollection pageOrderRules;
    private readonly List<Manual> manuals;

    public Solution(string rawInput)
    {
        var splitInput = rawInput.Split("\r\n\r\n");

        pageOrderRules = new(InputParser.ParseLines(splitInput[0]));
        manuals = InputParser.ParseLines(splitInput[1]).Select(m => new Manual(m)).ToList();
    }

    public string SolvePartOne()
    {
        int answer = 0;
        foreach (var manual in manuals)
        {
            if (pageOrderRules.IsValidManual(manual))
            {
                answer += GetMiddlePage(manual);
            }
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        foreach (var manual in manuals)
        {
            if (!pageOrderRules.IsValidManual(manual))
            {
                answer += GetMiddlePage(pageOrderRules.SortInvalidManual(manual));
            }
        }

        return answer.ToString();
    }

    private int GetMiddlePage(Manual manual)
    {
        return manual.PageNumbers[manual.PageNumbers.Count / 2];
    }

    private sealed class Manual
    {
        public List<int> PageNumbers { get; set; } = [];

        public Manual(string rawManual)
        {
            PageNumbers = rawManual.Split(",").Select(int.Parse).ToList();
        }
    }


    private sealed class PageOrderRule
    {
        public int PageNumber { get; set; }

        public List<int> RequiredFuturePages { get; set; } = [];

        public void AddRequiredFuturePage(int pageNumber)
        {
            RequiredFuturePages.Add(pageNumber);
        }
    }

    private sealed class PageOrderRuleCollection
    {
        public PageOrderRuleCollection(string[] input)
        {
            foreach (var rule in input)
            {
                var splitRule = rule.Split("|");
                var pageNumber = int.Parse(splitRule[0]);
                var futurePageNumber = int.Parse(splitRule[1]);

                AddRequiredFuturePage(pageNumber, futurePageNumber);
            }
        }

        public List<PageOrderRule> PageOrderRules { get; set; } = [];

        public PageOrderRule this[int pageNumber]
        {
            get
            {
                var rule = PageOrderRules.FirstOrDefault(r => r.PageNumber == pageNumber);
                if (rule == null)
                {
                    rule = new PageOrderRule { PageNumber = pageNumber };
                    PageOrderRules.Add(rule);
                }
                return rule;
            }
        }

        public void AddRequiredFuturePage(int pageNumber, int invalidPageNumber)
        {
            this[pageNumber].AddRequiredFuturePage(invalidPageNumber);
        }

        public bool IsValidPage(int currentPageNumber, int futurePageNumber)
        {
            return !this[futurePageNumber].RequiredFuturePages.Contains(currentPageNumber);
        }

        public bool IsValidManual(Manual manual)
        {
            var pageNumbers = manual.PageNumbers.ToArray();
            for (int i = 0; i < pageNumbers.Length; i++)
            {
                for (int j = i + 1; j < pageNumbers.Length; j++)
                {
                    if (!IsValidPage(pageNumbers[i], pageNumbers[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Manual SortInvalidManual(Manual manual)
        {
            var pageNumbers = manual.PageNumbers.ToArray();
            for (int i = 0; i < pageNumbers.Length; i++)
            {
                for (int j = i + 1; j < pageNumbers.Length; j++)
                {
                    if (!IsValidPage(pageNumbers[i], pageNumbers[j]))
                    {
                        var temp = pageNumbers[i];
                        pageNumbers[i] = pageNumbers[j];
                        pageNumbers[j] = temp;
                    }
                }
            }

            manual.PageNumbers = pageNumbers.ToList();
            return manual;
        }
    }
}
