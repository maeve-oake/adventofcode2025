namespace _7;

class Program
{
    static Dictionary<string, List<string>> splitters = new();
    static Dictionary<string, long> memo = new();

    static void Main(string[] args)
    {
        List<List<char>> lines = File.ReadAllLines("input.txt").Select(x => x.Replace('S', '|').ToList()).ToList();

        long splits = 0;

        for (int y = 1; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[y].Count(); x++)
            {
                if (lines[y][x] == '^') // p2
                {
                    string R = "out";
                    string L = "out";

                    for (int Ry = y; Ry < lines.Count; Ry++)
                    {
                        if (lines[Ry][x + 1] == '^') { R = Ry + "," + (x + 1); break; }
                    }
                    for (int Ly = y; Ly < lines.Count; Ly++)
                    {
                        if (lines[Ly][x - 1] == '^') { L = Ly + "," + (x - 1); break; }
                    }

                    splitters.Add(y + "," + x, [R, L]);
                }

                if (lines[y - 1][x] == '|') // p1
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

        Console.WriteLine("P1: " + splits);
        Console.WriteLine("P2: " + Traverse(splitters.First().Key));
    }

    static long Traverse(string start)
    {
        if (memo.ContainsKey(start)) { return memo[start]; }

        long paths = 0;

        splitters[start].ForEach(next =>
        {
            if (next == "out") { paths++; }
            else { paths += Traverse(next); }
        });

        memo[start] = paths;
        return paths;
    }
}
