namespace _3;

class Program
{
    static void Main(string[] args)
    {
        List<string> banks = File.ReadAllLines("input.txt").ToList();

        int p1 = banks.Select(bank =>
        {
            int highest = 0;
            int pos = 0;
            for (int i = 0; i < bank.Length - 1; i++)
            {
                if (highest < bank[i]) { highest = bank[i]; pos = i; }
            }
            return int.Parse(new String([(char)highest, new String(bank.Substring(pos + 1).OrderBy(x => x).ToArray()).Last()]));
        }).Sum();

        Console.WriteLine("P1: " + p1);

        long p2 = banks.Select(bank =>
        {
            string output = "";
            int pos = 0;
            for (int len = 11; len >= 0; len--)
            {
                int highest = 0;

                for (int i = pos; i < bank.Length - len; i++)
                {
                    if (highest < bank[i]) { highest = bank[i]; pos = i + 1; }
                }

                output += new string([(char)highest]);
            }

            return long.Parse(output);
        }).Sum();

        Console.WriteLine("P2: " + p2);
    }


}
