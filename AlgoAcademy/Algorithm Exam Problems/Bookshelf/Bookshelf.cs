using System;
using System.Collections.Generic;
using System.Linq;

class Bookshelf
{
    static void Main(string[] args)
    {
        const long MOD = 1000000033;
        decimal[] factorialMod = new decimal[100000 + 1];
        factorialMod[0] = 1;
        factorialMod[1] = 1;
        CalculateFactorials(factorialMod, MOD);

        string[] input = Console.ReadLine().Split();
        int uniqueBooks = int.Parse(input[0]);
        int sequenceBooks = int.Parse(input[1]);

        decimal finalResult = factorialMod[uniqueBooks + sequenceBooks];
        if (sequenceBooks != 0)
        {
            int[] sequences = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < sequenceBooks; i++)
            {
                finalResult = finalResult * factorialMod[sequences[i]] % MOD;
            }
        }

        Console.WriteLine(finalResult);
    }

    private static void CalculateFactorials(decimal[] factorialMod, ulong MOD)
    {
        for (int i = 2; i <= 100000; i++)
        {
            factorialMod[i] = factorialMod[i - 1] * i % MOD;
        }
    }
}

