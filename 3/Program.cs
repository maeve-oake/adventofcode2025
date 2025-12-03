using Microsoft.VisualBasic;

namespace _3;

class Program
{
    static void Main(string[] args)
    {
        List<string> banks = File.ReadAllLines("test.txt").ToList();

        int p1 = 0;
        long p2 = 0;

        banks.ForEach(bank =>
        {
            int highest = 0;
            int pos = 0;
            for (int i = 0; i < bank.Length - 1; i++)
            {
                if (highest < bank[i]) { highest = bank[i]; pos = i; }
            }
            int joltage = int.Parse(new String([(char)highest, new String(bank.Substring(pos + 1).OrderBy(x => x).ToArray()).Last()]));
            p1 += joltage;
            // Console.WriteLine("Bank: " + bank);
            // Console.WriteLine("Joltage: " + joltage);
        });
        Console.WriteLine("P1: " + p1);

        banks.ForEach(bank =>
        {
            /*
                i'm gonna try some wack ass recursive function.
                something along the lines of the highest leftmost character, then recurse
                when you hit the end but haven't hit 12 chars go up a level then find the highest leftmost again
                (making sure to insert the selection in the right index)

                maybe going from the OTHER direction could work? **remove** the leftmost lowest values?

                find lowest value in bank, then remove leftmost instance of it. repeat until bank is 12 long (doesn't work)
            */

            // string natwest = new string(bank);

            // while (natwest.Length > 12)
            // {
            //     char lowest = natwest.OrderBy(x => x).ToArray().First();

            //     for (int i = 0; i < natwest.Length; i++)
            //     {
            //         if (natwest[i] == lowest) { natwest = natwest.Remove(i, 1); break; }
            //     }
            // }
            // Console.WriteLine(natwest);
            // p2 += long.Parse(natwest);

            List<(int value, int pos)> natwest = bank.Select((ch, index) => (value: ch - '0', pos: index)).ToList();
            var sizes = natwest.OrderByDescending(num => num.value).ThenByDescending(num => num.pos).ToList();
            // once we "want" a number we cannot pick any more left of it. idfk

            Console.WriteLine();
        });

        Console.WriteLine("P2: " + p2);
    }
}
