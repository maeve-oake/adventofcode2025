namespace _5;

class Program
{
    static void Main(string[] args)
    {
        string[] text = File.ReadAllText("input.txt").Split("\n\n");
        List<(long a, long b)> ranges = text[0].Split("\n").Select(range => range.Split("-")).Select(parts => (a: long.Parse(parts[0]), b: long.Parse(parts[1]))).ToList();
        List<long> available = text[1].Split("\n").Select(long.Parse).ToList();

        int p1 = 0;

        available.ForEach(item =>
        {
            for (int i = 0; i < ranges.Count; i++)
            {
                if (item >= ranges[i].a && item <= ranges[i].b) { p1++; break; }
            }
        });

        long p2 = Condense(ranges).Select(range => { return range.b - range.a + 1; }).Sum();

        Console.WriteLine("P1: " + p1);
        Console.WriteLine("P2: " + p2);
    }

    static List<(long a, long b)> Condense(List<(long a, long b)> ranges)
    {
        List<(long a, long b)> working = new(ranges);

        for (int j = 0; j < working.Count; j++)
        {
            for (int i = 0; i < working.Count; i++)
            {
                if (i != j && (working[j].a <= working[i].b && working[j].a >= working[i].a || working[j].b >= working[i].a && working[j].b <= working[i].b))
                {
                    working[i] = new(
                        working[i].a < working[j].a ? working[i].a : working[j].a,
                        working[i].b > working[j].b ? working[i].b : working[j].b
                    );
                    working.Remove(working[j]);
                    return Condense(working);
                }
            }
        }

        return working;
    }
}
