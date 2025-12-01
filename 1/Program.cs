namespace _1;

class Program
{
    static void Main(string[] args)
    {
        int dial = 50;
        int p1 = 0;
        int p2 = 0;
        File.ReadAllLines("input.txt").ToList().ForEach(y =>
        {
            int x = int.Parse(y.Replace("L", "-").Replace("R", ""));

            for (int i = Math.Abs(x); i > 0; i--)
            {
                dial += Math.Sign(x);
                if (dial < 0) { dial = 99; }
                if (dial > 99) { dial = 0; }
                if (dial == 0) { p2++; }
            }

            if (dial == 0) { p1++; }

            // trying to be too smart:
            // if ((dial != 0) && (dial + x > 100 || dial + x < 0))
            // {
            //     int fullturns = Math.Abs(x) / 100;
            //     if (fullturns > 1) { p2 += fullturns; }
            //     else { p2++; }
            // }
            // dial = (dial + ((x % 100) + 100) % 100) % 100;
        });

        Console.WriteLine("Part 1: " + p1);
        Console.WriteLine("Part 2: " + p2);
    }
}
