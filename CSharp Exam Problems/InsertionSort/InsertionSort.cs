using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class InsertionSort
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbersArray = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            numbersArray[i] = int.Parse(input[i]);
        }

        InsertionSortAlgorithm(numbersArray);

        Console.WriteLine(string.Join(" ", numbersArray));
    }

    private static void InsertionSortAlgorithm(int[] numbersArray)
    {
        for (int i = 1; i < numbersArray.Length; i++)
        {
            if (numbersArray[i - 1] > numbersArray[i])
            {
                int j = i;
                while (j > 0 && numbersArray[j] < numbersArray[j - 1])
                {
                    int temp = numbersArray[j - 1];
                    numbersArray[j - 1] = numbersArray[j];
                    numbersArray[j] = temp;
                    j--;
                }
            }
        }
    }
}

