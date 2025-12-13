namespace _11;

class Program
{
    static Dictionary<string, List<string>> devices = File.ReadAllLines("input.txt").ToList().Select(line =>
    {
        return (line.Split(": ")[0], line.Split(": ")[1].Split(" ").ToList());
    }).ToDictionary();

    static Dictionary<string, long> mriaow = [];

    static void Main(string[] args)
    {
        Console.WriteLine("P1: " + nPath("you"));
        Console.WriteLine("P2: " + nPath2("svr", false, false));
    }

    static long nPath(string from)
    {
        if (devices[from].Contains("out"))
        {
            return 1;
        }

        return devices[from].Select(nPath).Sum();
    }

    static long nPath2(string from, bool fft, bool dac)
    {
        if (from == "dac") { dac = true; }
        if (from == "fft") { fft = true; }

        string cacheKey = from + dac + fft;

        if (mriaow.ContainsKey(cacheKey))
        {
            return mriaow[cacheKey];
        }

        if (devices[from].Contains("out"))
        {
            if (fft && dac)
            {
                mriaow[cacheKey] = 1;
                return 1;
            }

            mriaow[cacheKey] = 0;
            return 0;
        }

        long sum = devices[from].Select(n => nPath2(n, fft, dac)).Sum();
        mriaow[cacheKey] = sum;
        return sum;
    }
}
