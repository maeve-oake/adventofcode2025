namespace _9;

class Program
{
    static void Main(string[] args)
    {
        List<string> tiles = File.ReadAllLines("input.txt").ToList();

        long largestarea = 0;

        tiles.ForEach(tile =>
        {
            tiles.ForEach(nexttile =>
            {
                long area = (Math.Abs(long.Parse(tile.Split(",")[0]) - long.Parse(nexttile.Split(",")[0])) + 1) * (Math.Abs(long.Parse(tile.Split(",")[1]) - long.Parse(nexttile.Split(",")[1]) + 1));

                // Console.WriteLine("1: " + Math.Abs(int.Parse(tile.Split(",")[0])) + "," + Math.Abs(int.Parse(tile.Split(",")[1])));
                // Console.WriteLine("2: " + Math.Abs(int.Parse(nexttile.Split(",")[0])) + "," + Math.Abs(int.Parse(nexttile.Split(",")[1])));
                // Console.WriteLine("area: " + area);
                // Console.WriteLine("larg: " + largestarea);

                largestarea = area > largestarea ? area : largestarea;
            });
        });

        Console.WriteLine("P1: " + largestarea);
    }
}
