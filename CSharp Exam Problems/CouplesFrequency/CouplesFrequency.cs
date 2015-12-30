using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CouplesFrequency
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var occurances = new Dictionary<string, int>();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(numbers[i]);
            sb.Append(" ");
            sb.Append(numbers[i + 1]);

            if (!occurances.ContainsKey(sb.ToString()))
            {
                occurances.Add(sb.ToString(), 0);
            }

            occurances[sb.ToString()]++;
        }

        //foreach (KeyValuePair<string, int> item in occurances)
        //{
        //    double percentage = (item.Value * 100d) / (numbers.Length - 1);
        //    string[] keyNumbers = item.Key.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        //    Console.WriteLine("{0} {1} -> {2:F2}%", int.Parse(keyNumbers[0]), int.Parse(keyNumbers[1]), percentage);
        //}

        var final = occurances
            .Select(x => new
            {
                Percentage = (x.Value * 100d) / (numbers.Length - 1),
                KeyNumbers = x.Key.Split(new char[0], StringSplitOptions.RemoveEmptyEntries),
                Key = x.Key
            });

        foreach (var item in final)
        {
            Console.WriteLine("{0} {1} -> {2:F2}%", item.KeyNumbers[0], item.KeyNumbers[1], item.Percentage);
        }
    }
}

