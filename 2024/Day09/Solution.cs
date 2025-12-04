using AdventOfCode.Lib.Solutions;

namespace AdventOfCode.Y2024.Day09;

public sealed class Solution : ISolution
{
    private readonly string input;

    public Solution(string rawInput)
    {
        input = rawInput;
    }

    public string SolvePartOne()
    {
        int currentIndex = 0;
        int currentFileId = 0;
        LinkedList<Block> blocks = [];
        for (int i = 0; i < input.Length; i++)
        {
            int currentInput = int.Parse(input[i].ToString());
            if (i % 2 == 0)
            {
                for (int j = 0; j < currentInput; j++)
                {
                    blocks.AddLast(new Block(currentIndex, currentFileId));
                    currentIndex++;
                }
                currentFileId++;
            }
            else
            {
                for (int j = 0; j < currentInput; j++)
                {
                    blocks.AddLast(new Block(currentIndex, -1));
                    currentIndex++;
                }
            }
        }


        Block lastFileBlock = blocks.Last(b => b.HasFile);
        Block firstFreeBlock = blocks.First(b => !b.HasFile);

        while (firstFreeBlock.Index < lastFileBlock.Index)
        {
            //Console.WriteLine($"Current free index: {firstFreeBlock.Index} Last file index: {lastFileBlock.Index}");

            //PrintLinkedList(blocks);
            //Console.WriteLine($"Current Free Block Index: {currentFreeBlock.Index}");
            //Console.WriteLine($"Current File Block Index: {currentFileBlock.Index}");

            //Console.WriteLine($"Performing calculation: {currentFreeBlock.Index} * {currentFileBlock.FileId}");
            //answer += currentFreeBlock.Index * currentFileBlock.FileId;
            SwapBlocks(firstFreeBlock, lastFileBlock);

            lastFileBlock = blocks.Last(b => b.HasFile);
            firstFreeBlock = blocks.First(b => !b.HasFile);
            //Console.WriteLine();
        }

        //PrintLinkedList(blocks);

        return blocks.Sum(b => b.CheckSum).ToString();
    }

    public string SolvePartTwo()
    {
        int answer = 0;

        return answer.ToString();
    }

    private void PrintLinkedList(LinkedList<Block> list)
    {
        foreach (Block block in list)
        {
            if (block.HasFile)
            {
                Console.Write(block.FileId);
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
    }

    private sealed class Block
    {
        public long Index { get; set; }

        public int FileId { get; set; }

        public bool HasFile => FileId >= 0;

        public long CheckSum => HasFile ? Index * FileId : 0;

        public Block(int index, int fileId)
        {
            Index = index;
            FileId = fileId;
        }
    }

    private static void SwapBlocks(Block first, Block second)
    {
        if (first == null)
        {
            throw new ArgumentNullException("first");
        }

        if (second == null)
        {
            throw new ArgumentNullException("second");
        }

        var tmp = first.FileId;
        first.FileId = second.FileId;
        second.FileId = tmp;
    }
}
