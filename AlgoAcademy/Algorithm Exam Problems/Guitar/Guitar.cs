using System;
using System.Collections.Generic;
using System.Linq;

class Guitar
{
    private static int finalResult;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int startingPower = int.Parse(Console.ReadLine());
        int maxPower = int.Parse(Console.ReadLine());

        HashSetArraySolution(numbers, startingPower, maxPower, n);

        Console.WriteLine(finalResult);
    }

    /// <summary>
    /// With this method we generate the binary tree of all
    /// possible solutions and at the end we find the biggest
    /// of them.
    /// Memory required: ~10MB.
    /// Running time: 0.015s
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="startingPower"></param>
    /// <param name="maxPower"></param>
    /// <param name="n"></param>
    private static void HashSetArraySolution(int[] numbers, int startingPower, int maxPower, int n)
    {
        HashSet<int>[] setArray = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
        {
            setArray[i] = new HashSet<int>();
        }

        if (startingPower + numbers[0] <= maxPower)
        {
            setArray[0].Add(numbers[0] + startingPower);
        }
        if (startingPower - numbers[0] >= 0)
        {
            setArray[0].Add(startingPower - numbers[0]);
        }

        for (int i = 1; i < n; i++)
        {
            finalResult = 0;
            if (setArray[i - 1].Count == 0)
            {
                break;
            }

            foreach (int currentNumber in setArray[i - 1])
            {
                int num1 = currentNumber + numbers[i];
                int num2 = currentNumber - numbers[i];
                if (num1 <= maxPower)
                {
                    if (num1 > finalResult)
                    {
                        finalResult = num1;
                    }
                    setArray[i].Add(num1);
                }
                if (num2 >= 0)
                {
                    if (num2 > finalResult)
                    {
                        finalResult = num2;
                    }
                    setArray[i].Add(num2);
                }
            }
        }

        if (setArray[n - 1].Count == 0)
        {
            finalResult = -1;
        }
    }
}

