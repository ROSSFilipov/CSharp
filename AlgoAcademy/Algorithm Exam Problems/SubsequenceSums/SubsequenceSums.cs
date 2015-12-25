using System;
using System.Collections.Generic;
using System.Linq;

public class SubsequenceSums
{
    private static long[,] binomMatrix = new long[1000, 1000];
    static void Main(string[] args)
    {
        ExecuteSolution();
    }

    public static long CalculateSum(int[] numbers)
    {
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    public static void ExecuteSolution()
    {
        int turns = int.Parse(Console.ReadLine());
        for (int i = 0; i < turns; i++)
        {
            string[] nAndKValues = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            short n = short.Parse(nAndKValues[0]);
            short k = short.Parse(nAndKValues[1]);
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(CalculateCurrentSum(n, k, numbers));
        }
    }

    public static long CalculateCurrentSum(int n, int k, int[] numbers)
    {
        long binomCoefficient = CalculateBinomCoefficient(n - 1, k);
        long currentSum = binomCoefficient * CalculateSum(numbers);
        return currentSum;
    }

    private static long CalculateBinomCoefficient(int n, int k)
    {
        if (k > n)
        {
            return 0;
        }
        if (k == 0 || k == n)
        {
            return 1;
        }
        if (binomMatrix[n, k] == 0)
        {
            binomMatrix[n, k] = CalculateBinomCoefficient(n - 1, k - 1) + CalculateBinomCoefficient(n - 1, k);
        }

        return binomMatrix[n, k];
    }
}

