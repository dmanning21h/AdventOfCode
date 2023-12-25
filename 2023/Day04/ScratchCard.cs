using System.Text.RegularExpressions;

namespace Day04;

public sealed class ScratchCard
{
    public int GameNumber { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> Numbers { get; set; }
    public int CardCopies { get; set; }

    public List<int> MatchingNumbers => Numbers.Intersect(WinningNumbers).ToList();

    public int CardScore => MatchingNumbers.Count > 0 ? (int)Math.Pow(2.0, MatchingNumbers.Count - 1) : 0;

    public List<int>? BonusCardNumbers => MatchingNumbers.Count > 0 ? Enumerable.Range(GameNumber + 1, MatchingNumbers.Count).ToList() : null;


    public ScratchCard(string input)
    {
        CardCopies = 1;
        var gameAndNumbers = input.Split(":");
        var gameNumber = Regex.Match(gameAndNumbers[0], @"\d+").Value;
        GameNumber = int.Parse(gameNumber);

        var winningNumbersAndNumbers = gameAndNumbers[1].Split("|");
        var winningNumbers = winningNumbersAndNumbers[0].Split(" ").Where(x => x.Length > 0);
        var numbers = winningNumbersAndNumbers[1].Split(" ").Where(x => x.Length > 0);
        WinningNumbers = winningNumbers.Select(int.Parse).ToList();
        Numbers = numbers.Select(int.Parse).ToList();
    }
}
