using AdventOfCode.Lib;

namespace AdventOfCode.Y2024.Day06;

public sealed class Solution : ISolution
{
    private readonly LabPatrol labPatrol;

    public Solution(string rawInput) => labPatrol = new LabPatrol(rawInput);

    public string SolvePartOne() => labPatrol.PatrolV1().ToString();

    public string SolvePartTwo() => labPatrol.PatrolV2().ToString();

    private sealed class LabPatrol
    {
        public Grid Grid { get; init; }

        private Coordinate GuardCoordinate { get; set; }

        private Direction CurrentDirection { get; set; } = Direction.Up;

        private bool IsGuardInLab => CoordinateIsInGrid(GuardCoordinate);

        private HashSet<(int x, int y)> visitedPositions = [];
        private HashSet<(int x, int y, int dx, int dy)> visitedVectors = [];

        public LabPatrol(string rawInput)
        {
            List<List<char>> charGrid = rawInput.Split("\r\n").Select(line => line.ToList()).ToList();

            Grid = new Grid(charGrid);

            GuardCoordinate = Grid.Coordinates.SelectMany(row => row).First(coord => coord.Value == '^');
        }

        public int PatrolV1()
        {
            while (IsGuardInLab)
            {
                int dx = GetDx(CurrentDirection);
                int dy = GetDy(CurrentDirection);

                var nextMoveCoordinate = new Coordinate(GuardCoordinate.X + dx, GuardCoordinate.Y + dy);
                if (CoordinateIsInGrid(nextMoveCoordinate))
                {
                    if (Grid[nextMoveCoordinate].Value == '#')
                    {
                        Turn();
                        continue;
                    }
                }

                visitedPositions.Add((GuardCoordinate.X, GuardCoordinate.Y));
                visitedVectors.Add((GuardCoordinate.X, GuardCoordinate.Y, dx, dy));

                GuardCoordinate = nextMoveCoordinate;
            }

            return visitedPositions.Count;
        }

        public int PatrolV2()
        {
            int obstructionPoints = 0;
            GuardCoordinate = Grid.Coordinates.SelectMany(row => row).First(coord => coord.Value == '^');
            var initialGuardPosition = (GuardCoordinate.X, GuardCoordinate.Y);

            foreach (var (x, y) in visitedPositions)
            {
                if ((x, y) == initialGuardPosition)
                {
                    continue;
                }

                Grid.Coordinates[y][x].Value = '#';

                GuardCoordinate = Grid.Coordinates.SelectMany(row => row).First(coord => coord.Value == '^');
                CurrentDirection = Direction.Up;

                var localVisitedVectors = new HashSet<(int x, int y, int dx, int dy)>();

                while (IsGuardInLab)
                {
                    int dx = GetDx(CurrentDirection);
                    int dy = GetDy(CurrentDirection);

                    var nextMoveCoordinate = new Coordinate(GuardCoordinate.X + dx, GuardCoordinate.Y + dy);
                    if (CoordinateIsInGrid(nextMoveCoordinate))
                    {
                        if (Grid[nextMoveCoordinate].Value == '#')
                        {
                            Turn();
                            continue;
                        }
                    }

                    var currentPos = (GuardCoordinate.X, GuardCoordinate.Y, GetDx(CurrentDirection), GetDy(CurrentDirection));
                    if (localVisitedVectors.Contains(currentPos))
                    {
                        obstructionPoints++;
                        break;
                    }
                    else
                    {
                        localVisitedVectors.Add(currentPos);
                    }

                    GuardCoordinate = nextMoveCoordinate;
                }

                Grid.Coordinates[y][x].Value = '.';
            }

            return obstructionPoints;
        }

        private void Turn()
        {
            CurrentDirection = CurrentDirection switch
            {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                _ => throw new InvalidOperationException("Invalid direction")
            };
        }

        private int GetDx(Direction direction)
        {
            return direction switch
            {
                Direction.Right => 1,
                Direction.Left => -1,
                _ => 0
            };
        }

        private int GetDy(Direction direction)
        {
            return direction switch
            {
                Direction.Up => -1,
                Direction.Down => 1,
                _ => 0
            };
        }

        private bool CoordinateIsInGrid(Coordinate coordinate)
        {
            return (coordinate.X >= 0 && coordinate.X < Grid.Coordinates[0].Count) && (coordinate.Y >= 0 && coordinate.Y < Grid.Coordinates.Count);
        }
    }

    private sealed record Grid
    {
        public List<List<Coordinate>> Coordinates { get; init; }

        public Grid(List<List<char>> charGrid)
        {
            Coordinates = [];
            foreach (var row in charGrid)
            {
                List<Coordinate> coords = [];
                foreach (var item in row)
                {
                    int x = row.IndexOf(item);
                    int y = charGrid.IndexOf(row);
                    coords.Add(new Coordinate(x, y) { Value = item });
                }

                Coordinates.Add(coords);
            }
        }

        public Coordinate this[Coordinate coordinate]
        {
            get
            {
                return Coordinates[coordinate.Y][coordinate.X];
            }
        }
    }

    public record Coordinate
    {
        public int X { get; init; }

        public int Y { get; init; }

        public char Value { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
