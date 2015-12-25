using System;
using System.Collections.Generic;

class ColourBalls
{
    private static long solutionsCounter = 0;
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        char[] letters = input.ToCharArray();
        Array.Sort(letters);
        //GeneratePermutations(letters, 0, letters.Length - 1);

        FastSolution(letters);

        Console.WriteLine(solutionsCounter);
    }

    /// <summary>
    /// The fast solution is factorial based. We however
    /// do not calculate the factorials directly as it
    /// will cause a value type overflow even if using 
    /// decimal value type.
    /// </summary>
    /// <param name="letters"></param>
    private static void FastSolution(char[] letters)
    {
        int arrayLength = letters.Length;
        int[] nominators = new int[arrayLength + 1];

        for (int i = 2; i <= arrayLength; i++)
        {
            CalculateDivisors(nominators, i);
        }

        List<int> colourIndexes = new List<int>();

        int[] denominators = new int[arrayLength + 1];

        FindColours(colourIndexes, letters, arrayLength);

        for (int i = 0; i < colourIndexes.Count; i++)
        {
            for (int j = 2; j <= colourIndexes[i]; j++)
            {
                CalculateDivisors(denominators, j);
            }
        }

        DeleteEqual(numerators, denominators, arrayLength);

        long finalNumerator = CalculateProduct(nominators, arrayLength);
        long finalDenominator = CalculateProduct(denominators, arrayLength);

        solutionsCounter = finalNumerator / finalDenominator;
    }

    /// <summary>
    /// This method splits a number by divisors starting from 2.
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="number"></param>
    private static void CalculateDivisors(int[] collection, int number)
    {
        int temp = number;
        int divisor = 2;
        while (temp > 1)
        {
            if (temp % divisor == 0)
            {
                temp /= divisor;
                collection[divisor]++;
            }
            else
            {
                divisor++;
            }
        }
    }

    /// <summary>
    /// We find here the count of all different colours.
    /// </summary>
    /// <param name="colourIndexes"></param>
    /// <param name="letters"></param>
    /// <param name="arrayLength"></param>
    private static void FindColours(List<int> colourIndexes, char[] letters, int arrayLength)
    {
        int currentIndex = 1;
        char currentColour = letters[0];
        for (int i = 1; i < arrayLength; i++)
        {
            if (letters[i] == currentColour)
            {
                currentIndex++;
            }
            else
            {
                colourIndexes.Add(currentIndex);
                currentIndex = 1;
                currentColour = letters[i];
            }
        }

        colourIndexes.Add(currentIndex);
    }

    /// <summary>
    /// We use this method to calculate the products of
    /// the nominators and denominators.
    /// </summary>
    /// <param name="numbersArray"></param>
    /// <param name="arrayLength"></param>
    /// <returns></returns>
    private static long CalculateProduct(int[] numbersArray, int arrayLength)
    {
        long sum = 1;
        for (int i = 2; i <= arrayLength; i++)
        {
            if (numbersArray[i] != 0)
            {
                sum *= GetPower(i, numbersArray[i]);
            }
        }

        return sum;
    }

    private static long GetPower(int number, int power)
    {
        long sum = 1;
        for (int i = 0; i < power; i++)
        {
            sum *= number;
        }

        return sum;
    }

    private static void DeleteEqual(int[] numerators, int[] denominators, int arrayLength)
    {
        for (int i = 0; i < arrayLength; i++)
        {
            if (numerators[i] >= denominators[i])
            {
                numerators[i] -= denominators[i];
                denominators[i] = 0;
            }
            else
            {
                denominators[i] -= numerators[i];
                numerators[i] = 0;
            }
        }
    }

    private static void GeneratePermutations(char[] letters, int start, int end)
    {
        solutionsCounter++;

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (letters[left] != letters[right])
                {
                    Swap(letters, left, right);
                    GeneratePermutations(letters, left + 1, end);
                }
            }

            var firstElement = letters[left];
            for (int i = left; i <= end - 1; i++)
            {
                letters[i] = letters[i + 1];
            }

            letters[end] = firstElement;
        }
    }

    private static void Swap(char[] letters, int i, int index)
    {
        char temp = letters[i];
        letters[i] = letters[index];
        letters[index] = temp;
    }
}

