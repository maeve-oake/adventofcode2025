using System.Diagnostics;

namespace _2;

class Program
{
    static void Main(string[] args)
    {
        long p1 = 0;
        long p2 = 0;

        List<Tuple<long, long>> ranges = [];
        File.ReadAllText("input.txt").Split(",").ToList().ForEach(x =>
        {
            ranges.Add(new Tuple<long, long>(long.Parse(x.Split("-")[0]), long.Parse(x.Split("-")[1])));
        });

        ranges.ForEach(range =>
        {
            Console.WriteLine("Range: " + range.Item1 + "-" + range.Item2);
            for (long i = range.Item1; i <= range.Item2; i++) // iterate values within range
            {
                // i started with going through all factors, instead i just need 1 and halves..
                string num = i.ToString();

                if (num.Length % 2 == 0 && (num.Distinct().Count() == 1 || num[..(num.Length / 2)] == num.Substring(num.Length / 2, num.Length / 2)))
                {
                    p1 += i;
                    // Console.WriteLine("i: " + i);
                    // Console.WriteLine("sum: " + p1);
                }

                // so what's really funny - i wrote the below code first. I didn't fully understand P1 and ended up engineering P2 first LOL

                // we need to split into groups of all common factors (len 5 means only factors are 1 and 5, so 22222 etc could be valid.)
                // splitting each number into portions of each factor length, we can then just see if they're disctinct or not
                int len = num.Length;
                for (int factor = 1; factor <= len; factor++) // iterate through factors
                {
                    if (len % factor == 0 && factor != len)
                    {
                        List<string> parts = [];

                        for (int j = 0; j < len; j += factor)
                        {
                            parts.Add(num.Substring(j, factor));
                        }

                        if (parts.Distinct().Count() == 1)
                        {
                            p2 += i;
                            // Console.WriteLine("i: " + i + " f: " + factor);
                            // Console.WriteLine("sum: " + p1);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine();
        });

        Console.WriteLine("Part 1: " + p1);
        Console.WriteLine("Part 2: " + p2);
    }
}
