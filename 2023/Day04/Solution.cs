namespace Day04;

public sealed class Solution
{
    public List<ScratchCard> ScratchCards { get; set; }

    public Solution(string[] input)
    {
        ScratchCards = [];
        foreach (var line in input)
        {
            ScratchCards.Add(new ScratchCard(line));
        }
    }

    public void SolvePartOne()
    {
        int answer = 0;
        foreach (var card in ScratchCards)
        {
            answer += card.CardScore;
        }

        Console.WriteLine($"Part One: {answer}");
    }

    public void SolvePartTwo()
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

        Console.WriteLine($"Part Two: {answer}");
    }
}
