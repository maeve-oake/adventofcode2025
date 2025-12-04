namespace _4;

class Program
{
    static void Main(string[] args)
    {
        List<string> warehouse = File.ReadAllLines("input.txt").ToList();
        Console.WriteLine("P1: " + FindRolls(warehouse).Count);

        int p2 = 0;
        while (true)
        {
            List<(int y, int x)> found = FindRolls(warehouse);
            p2 += found.Count;
            List<string> newwarehouse = RemoveRolls(found, warehouse);
            if (found.Count == 0) { break; }
            warehouse = newwarehouse;
        }

        Console.WriteLine("P2: " + p2);
    }

    static List<(int y, int x)> FindRolls(List<string> warehouse)
    {
        List<(int y, int x)> removed = new();
        for (int y = 0; y < warehouse.Count; y++)
        {
            for (int x = 0; x < warehouse[y].Length; x++)
            {
                if (warehouse[y][x] == '@')
                {
                    int surroundings = 0;
                    if (x != 0 && warehouse[y][x - 1] == '@') { surroundings++; }
                    if (x != warehouse[y].Length - 1 && warehouse[y][x + 1] == '@') { surroundings++; }
                    if (y != 0 && warehouse[y - 1][x] == '@') { surroundings++; }
                    if (y != warehouse.Count - 1 && warehouse[y + 1][x] == '@') { surroundings++; }
                    if (y != 0 && x != 0 && warehouse[y - 1][x - 1] == '@') { surroundings++; }
                    if (y != warehouse.Count - 1 && x != warehouse[y].Length - 1 && warehouse[y + 1][x + 1] == '@') { surroundings++; }
                    if (y != warehouse.Count - 1 && x != 0 && warehouse[y + 1][x - 1] == '@') { surroundings++; }
                    if (y != 0 && x != warehouse[y].Length - 1 && warehouse[y - 1][x + 1] == '@') { surroundings++; }
                    if (surroundings < 4) { removed.Add(new(y, x)); }
                }
            }
        }

        return removed;
    }

    static List<string> RemoveRolls(List<(int y, int x)> remove, List<string> oldwarehouse)
    {
        List<List<char>> warehouse = new(oldwarehouse.Select(z => z.ToList()));
        remove.ForEach(loc =>
        {
            warehouse[loc.y][loc.x] = '.';
        });

        return warehouse.Select(z => new string(z.ToArray())).ToList();
    }
}
