using System;
using System.Collections.Generic;
using System.Linq;

class ColourRabbits
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] rabbits = new int[n];

        for (int i = 0; i < n; i++)
        {
            rabbits[i] = int.Parse(Console.ReadLine());
        }

        bool[] used = new bool[n];

        long leastNumberOfRabbits = CalculateNumberOfRabbits(rabbits, used, n);

        Console.WriteLine(leastNumberOfRabbits);
    }

    private static long CalculateNumberOfRabbits(int[] rabbits, bool[] used, int n)
    {
        long rabbitSum = 0;

        for (int i = 0; i < n; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                int counter = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (rabbits[i] == rabbits[j] && !used[j])
                    {
                        used[j] = true;
                        counter++;
                    }
                }

                int result;
                if (counter % (rabbits[i] + 1) == 0)
                {
                    result = (counter / (rabbits[i] + 1)) * (rabbits[i] + 1);
                }
                else
                {
                    result = (counter / (rabbits[i] + 1) + 1) * (rabbits[i] + 1);
                }

                rabbitSum += result;
            }
        }

        return rabbitSum;
    }
}

