using AdventOfCode.Lib;

namespace AdventOfCode.Y2022.Day02;

public sealed class Solution : BaseSolution, ISolution
{
    public Solution(string rawInput) : base(rawInput)
    { }

    public string SolvePartOne()
    {
        var score = 0;
        foreach (var line in input)
        {
            var parts = line.Split(" ");
            var opponentMove = MapOpponentInputToMove(parts[0]);
            var myMove = MapPlayerInputToMove(parts[1]);
            var calculatedResult = CalculateResult(opponentMove, myMove);

            score += (int)calculatedResult + (int)myMove;
        }

        return score.ToString();
    }

    public string SolvePartTwo()
    {
        var score = 0;
        foreach (var line in input)
        {
            var parts = line.Split(" ");
            var opponentMove = MapOpponentInputToMove(parts[0]);
            var desiredResult = MapInputToResult(parts[1]);
            var myMove = DetermineMove(opponentMove, desiredResult);
            score += (int)desiredResult + (int)myMove;
        }

        return score.ToString();
    }

    private enum Move
    {
        Rock = 1,
        Paper,
        Scissors
    }

    private enum Result
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }

    private Move MapOpponentInputToMove(string input)
    {
        return input switch
        {
            "A" => Move.Rock,
            "B" => Move.Paper,
            "C" => Move.Scissors,
            _ => throw new ArgumentException("Invalid input.")
        };
    }

    private Move MapPlayerInputToMove(string input)
    {
        return input switch
        {
            "X" => Move.Rock,
            "Y" => Move.Paper,
            "Z" => Move.Scissors,
            _ => throw new ArgumentException("Invalid input.")
        };
    }

    private Result MapInputToResult(string input)
    {
        return input switch
        {
            "X" => Result.Loss,
            "Y" => Result.Draw,
            "Z" => Result.Win,
            _ => throw new ArgumentException("Invalid input.")
        };
    }

    private Result CalculateResult(Move opponentMove, Move myMove)
    {
        return (opponentMove, myMove) switch
        {
            (Move.Rock, Move.Paper) => Result.Win,
            (Move.Paper, Move.Scissors) => Result.Win,
            (Move.Scissors, Move.Rock) => Result.Win,
            (Move.Rock, Move.Rock) => Result.Draw,
            (Move.Paper, Move.Paper) => Result.Draw,
            (Move.Scissors, Move.Scissors) => Result.Draw,
            (Move.Rock, Move.Scissors) => Result.Loss,
            (Move.Paper, Move.Rock) => Result.Loss,
            (Move.Scissors, Move.Paper) => Result.Loss,
            _ => throw new ArgumentException("Invalid input.")
        };
    }

    private Move DetermineMove(Move opponentMove, Result desiredResult)
    {
        return (opponentMove, desiredResult) switch
        {
            (Move.Rock, Result.Win) => Move.Paper,
            (Move.Paper, Result.Win) => Move.Scissors,
            (Move.Scissors, Result.Win) => Move.Rock,
            (Move.Rock, Result.Draw) => Move.Rock,
            (Move.Paper, Result.Draw) => Move.Paper,
            (Move.Scissors, Result.Draw) => Move.Scissors,
            (Move.Rock, Result.Loss) => Move.Scissors,
            (Move.Paper, Result.Loss) => Move.Rock,
            (Move.Scissors, Result.Loss) => Move.Paper,
            _ => throw new ArgumentException("Invalid input.")
        };
    }
}
