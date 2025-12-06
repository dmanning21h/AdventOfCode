using AdventOfCode.Lib.Geometry;

namespace AdventOfCode.Lib.Input;

public static class InputParser
{
    /// <summary>
    /// Splits the specified input string into an array of lines using carriage return and line feed (CRLF) delimiters.
    /// </summary>
    /// <param name="rawInput">The input string to be parsed into lines. Lines are separated by the "\r\n" sequence.</param>
    /// <returns>An array of strings, each representing a non-empty line from the input. Lines containing only whitespace or
    /// empty lines are excluded.</returns>
    public static string[] ParseLines(string rawInput)
    {
        return rawInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Splits the specified input string into an array of lines using the provided delimiter character.
    /// </summary>
    /// <param name="rawInput">The input string containing lines to be parsed. Cannot be null.</param>
    /// <param name="delimiter">The character used to separate lines within the input string.</param>
    /// <returns>An array of strings, each representing a line parsed from the input. Returns an empty array if the input is
    /// empty.</returns>
    public static string[] ParseLines(string rawInput, char delimiter)
    {
        return rawInput.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Parses a string representation of a two-dimensional grid into a <see cref="Grid2D"/> instance.
    /// </summary>
    /// <remarks>The input string must use "\r\n" as the line separator. Each line is interpreted as a row,
    /// and each character as a cell in the grid. No validation is performed on the input format; malformed input may
    /// result in unexpected grid structure.</remarks>
    /// <param name="rawInput">The raw input string containing grid rows separated by carriage return and line feed ("\r\n"). Each line
    /// represents a row of characters in the grid.</param>
    /// <returns>A <see cref="Grid2D"/> object constructed from the parsed grid data.</returns>
    public static Grid2D ParseGrid2D(string rawInput)
    {
        var charGrid2D = rawInput.Split("\r\n").Select(line => line.ToList()).ToList();

        return new Grid2D(charGrid2D);
    }
}
