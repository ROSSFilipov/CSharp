using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// First we will remove all zeroes from the initial array
/// and then we will calculate the number of divisors for all
/// possible permutations of the array.
/// </summary>
class Divisors
{
    private static int maxDivisors = int.MaxValue;
    private static int smallestNumber = 0;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int[] finalArray = numbers.Where(x => x != 0).ToArray();

        CalculateDivisors(finalArray, 0);

        Console.WriteLine(smallestNumber);
    }

    private static void CalculateDivisors(int[] finalArray, int index)
    {
        if (index >= finalArray.Length)
        {
            int currentNumber = int.Parse(string.Join("", finalArray));
            int currentDivisors = CalculateNumberOfDivisors(currentNumber);

            if (currentDivisors < maxDivisors)
            {
                maxDivisors = currentDivisors;
                smallestNumber = currentNumber;
            }
            else if (currentDivisors == maxDivisors && smallestNumber > currentNumber)
            {
                smallestNumber = currentNumber;
            }

            return;
        }

        for (int i = index; i < finalArray.Length; i++)
        {
            Swap(finalArray, i, index);
            CalculateDivisors(finalArray, index + 1);
            Swap(finalArray, i, index);
        }
    }

    private static void Swap(int[] finalArray, int i, int index)
    {
        if (i == index)
        {
            return;
        }

        finalArray[i] ^= finalArray[index];
        finalArray[index] ^= finalArray[i];
        finalArray[i] ^= finalArray[index];
    }

    private static int CalculateNumberOfDivisors(int finalNumber)
    {
        int divisorsCounter = 0;
        for (int i = 1; i <= finalNumber; i++)
        {
            if (finalNumber % i == 0)
            {
                divisorsCounter++;
            }
        }

        return divisorsCounter;
    }
}

