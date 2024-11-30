using AdventOfCode.Lib;
using Day04;

var filePath = "input.txt";

var input = InputReader.ReadInput(filePath);

Solution Solution = new(input);

Solution.SolvePartOne();
Solution.SolvePartTwo();
