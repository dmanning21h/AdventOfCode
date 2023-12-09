namespace Day03;

public sealed class EngineSchematic
{
    public List<SchematicLine> SchematicLines { get; set; }

    public EngineSchematic(string[] input)
    {
        SchematicLines = new List<SchematicLine>();
        ParseSchematicLines(input, SchematicLines);
        SetValidSchematicLinePartNumbers(SchematicLines);
        SetValidGears(SchematicLines);
    }

    private void ParseSchematicLines(string[] input, List<SchematicLine> schematicLines)
    {
        foreach (var line in input)
        {
            schematicLines.Add(new SchematicLine(line));
        }
    }

    private void SetValidSchematicLinePartNumbers(List<SchematicLine> schematicLines)
    {
        for (int i = 0; i < schematicLines.Count; i++)
        {
            var symbols = schematicLines[i].Symbols.ToList();
            if (i > 0)
            {
                symbols.AddRange(schematicLines[i - 1].Symbols);
            }
            if (i < schematicLines.Count - 1)
            {
                symbols.AddRange(schematicLines[i + 1].Symbols);
            }

            foreach (var partNumber in schematicLines[i].PartNumbers)
            {
                partNumber.IsValid = symbols.Any(s => partNumber.IsValidSymbolIndex(s.Index));
            }
        }
    }

    private void SetValidGears(List<SchematicLine> schematicLines)
    {
        for (int i = 0; i < schematicLines.Count; i++)
        {
            var partNumbers = schematicLines[i].PartNumbers.ToList();
            if (i > 0)
            {
                partNumbers.AddRange(schematicLines[i - 1].PartNumbers);
            }
            if (i < schematicLines.Count - 1)
            {
                partNumbers.AddRange(schematicLines[i + 1].PartNumbers);
            }

            foreach (var gear in schematicLines[i].Gears)
            {
                gear.Validate(partNumbers);
            }
        }
    }
}

public sealed class SchematicLine
{
    public List<PartNumber> PartNumbers;
    public List<Symbol> Symbols;
    public List<Gear> Gears;

    public SchematicLine(string inputLine)
    {
        PartNumbers = new List<PartNumber>();
        Symbols = new List<Symbol>();
        Gears = new List<Gear>();
        ParseData(inputLine, Symbols, PartNumbers, Gears);
    }

    private void ParseData(string inputLine, List<Symbol> symbols, List<PartNumber> partNumbers, List<Gear> gears)
    {
        for (int i = 0; i < inputLine.Length; i++)
        {
            if (Symbol.IsSymbol(inputLine[i]))
            {
                Symbols.Add(new Symbol(i, inputLine[i]));
                if (inputLine[i] == '*')
                {
                    Gears.Add(new Gear(i));
                }
            }
            else if (char.IsNumber(inputLine[i]))
            {
                var newPartNumber = ParsePartNumber(inputLine, i);
                PartNumbers.Add(newPartNumber);
                i = newPartNumber.EndIndex;
            }
        }
    }

    private PartNumber ParsePartNumber(string inputLine, int startIndex)
    {
        string currentNumber = "";
        bool isNumber = true;
        int i = startIndex;
        while (isNumber)
        {
            currentNumber += inputLine[i];
            i++;
            if (i == inputLine.Length)
            {
                isNumber = false;
            }
            else if (!char.IsNumber(inputLine[i]))
            {
                isNumber = false;
            }
        }
        i--;

        int number = int.Parse(currentNumber);
        return new PartNumber(startIndex, i, number);
    }
}

public sealed class Symbol
{
    public int Index { get; set; }
    public char Value { get; set; }

    public Symbol(int index, char value)
    {
        Index = index;
        Value = value;
    }

    private static string SymbolSet = "=+-/*@&#$%";
    public static bool IsSymbol(char c)
    {
        return c != '.' && SymbolSet.Contains(c);
    }
}

public sealed class Gear
{
    public int Index { get; set; }
    public bool IsValid { get; set; }
    public int GearRatio { get; set; }

    public Gear(int index)
    {
        Index = index;
    }

    public void Validate(IEnumerable<PartNumber> partNumbers)
    {
        var validPartNumbers = partNumbers.Where(p => p.IsValidSymbolIndex(Index)).Select(p => p.Value);

        if (validPartNumbers.Count() == 2)
        {
            IsValid = true;
            GearRatio = validPartNumbers.Aggregate((a, x) => a * x);
        }
    }
}

public sealed class PartNumber
{
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public int Value { get; set; }
    public bool IsValid { get; set; }

    public PartNumber(int startIndex, int endIndex, int value)
    {
        StartIndex = startIndex;
        EndIndex = endIndex;
        Value = value;
    }

    public bool IsValidSymbolIndex(int symbolIndex)
    {
        return symbolIndex >= StartIndex - 1 && symbolIndex <= EndIndex + 1;
    }
}