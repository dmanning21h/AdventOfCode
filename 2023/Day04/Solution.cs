using AdventOfCode.Lib;

namespace AdventOfCode.Y2023.Day04;

public sealed class Solution : ISolution
{
    public List<ScratchCard> ScratchCards { get; set; }

    public Solution(string input)
    {
        ScratchCards = [];
        foreach (var line in input.Split("\r\n"))
        {
            ScratchCards.Add(new ScratchCard(line));
        }
    }

    public string SolvePartOne()
    {
        int answer = 0;
        foreach (var card in ScratchCards)
        {
            answer += card.CardScore;
        }

        return answer.ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;
        foreach (var card in ScratchCards)
        {
            if (card.BonusCardNumbers != null)
            {
                foreach (var bonusCardNumber in card.BonusCardNumbers)
                {
                    ScratchCards.Find(sc => sc.GameNumber == bonusCardNumber).CardCopies += card.CardCopies;
                }
            }
        }

        foreach (var card in ScratchCards)
        {
            answer += card.CardCopies;
        }

        return answer.ToString();
    }
}
