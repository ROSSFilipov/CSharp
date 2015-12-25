using System;
using System.Collections.Generic;
using System.Linq;

class BinaryPasswords
{
    private const int NumberOfElements = 2;
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int numberOfStars = GetNumberOfStars(input);

        long sum = 1;

        for (int i = 0; i < numberOfStars; i++)
        {
            sum *= NumberOfElements;
        }

        Console.WriteLine(sum);
    }

    /// <summary>
    /// We calculate how many empty spaces there are
    /// in the input sequence and then we will raise
    /// the number as a power of 2.
    /// </summary>
    /// <param name="input">The original input sequence.</param>
    /// <returns></returns>
    private static int GetNumberOfStars(string input)
    {
        int counter = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '*')
            {
                counter++;
            }
        }

        return counter;
    }
}

