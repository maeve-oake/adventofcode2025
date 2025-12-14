namespace _7;

class Program
{
    static void Main(string[] args)
    {
        List<List<char>> lines = File.ReadAllLines("test.txt").Select(x => x.Replace('S', '|').ToList()).ToList();

        lines.RemoveAll(x => x.Distinct().Count() == 1);

        long splits = 0;

        for (int y = 1; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[y].Count(); x++)
            {
                if (lines[y - 1][x] == '|')
                {
                    if (lines[y][x] == '.') { lines[y][x] = '|'; }
                    else if (lines[y][x] == '^')
                    {
                        lines[y][x + 1] = '|';
                        lines[y][x - 1] = '|';
                        splits++;
                    }
                }
            }
        }

        List<(int y, int x, string L, string R)> splitters = new();


        for (int y = 1; y < lines.Count; y++)
        {

        }


        Console.WriteLine("P1: " + splits);
    }
}
