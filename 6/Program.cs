using System.Text.RegularExpressions;

namespace _6;

class Program
{
    static void Main(string[] args)
    {
        List<string> questions = File.ReadAllLines("input.txt").ToList();
        List<char> op = questions[^1].ToList();
        op.RemoveAll(x => x == ' ');
        questions.RemoveAt(questions.Count - 1);
        List<List<long>> numbers = questions.Select(x => Regex.Replace(x, " {2,}", " ").Trim().Split(" ").Select(long.Parse).ToList()).ToList();

        long p1 = 0;

        for (int i = 0; i < op.Count; i++)
        {
            long cur = 1;

            numbers.ForEach(num =>
            {
                if (op[i] == '+') { p1 += num[i]; }
                else { cur *= num[i]; }
            });

            if (op[i] == '*') { p1 += cur; }
        }

        long p2 = 0;
        List<List<int>> p2numbers = new();
        List<int> currNums = new();

        for (int x = 0; x < questions[0].Length; x++)
        {
            string currQ = "";
            for (int y = 0; y < questions.Count; y++)
            {
                currQ += questions[y][x];
            }

            currQ = currQ.Trim();

            if (string.IsNullOrEmpty(currQ))
            {
                p2numbers.Add(currNums);
                currNums = new();
            }
            else
            {
                currNums.Add(int.Parse(currQ));
            }
        }

        p2numbers.Add(currNums);

        for (int i = 0; i < op.Count; i++)
        {
            if (op[i] == '+') { p2 += p2numbers[i].Sum(); }
            else
            {
                long curr = 1;
                p2numbers[i].ForEach(x => curr *= x);
                p2 += curr;
            }
        }

        Console.WriteLine("P1: " + p1);
        Console.WriteLine("P2: " + p2);
    }
}
