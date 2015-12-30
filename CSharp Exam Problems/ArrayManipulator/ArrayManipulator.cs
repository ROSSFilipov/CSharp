using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

class ArrayManipulator
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        //int[] input = new int[] { 1, 10, 100, 1000 };

        while (true)
        {

            string currentCommand = Console.ReadLine();

            if (currentCommand == "end")
            {
                break;
            }

            string[] commandSplit = currentCommand.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            switch (commandSplit[0])
            {
                case "exchange": ExecuteExchange(input, BigInteger.Parse(commandSplit[1]));
                    break;
                case "max": GetIndexOfMaxElement(input, commandSplit[1]);
                    break;
                case "min": GetIndexOfMinElement(input, commandSplit[1]);
                    break;
                case "first": GetFirstElements(input, BigInteger.Parse(commandSplit[1]), commandSplit[2]);
                    break;
                case "last": GetLastElements(input, BigInteger.Parse(commandSplit[1]), commandSplit[2]);
                    break;
                default:
                    {
                        throw new InvalidOperationException("This should never happen.");
                    }
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", input));
    }

    private static void GetLastElements(int[] input, BigInteger count, string command)
    {
        if (count > input.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        List<int> tempList = new List<int>();

        int currentIndex = input.Length - 1;
        while (count > 0 && currentIndex >= 0)
        {
            if (command == "even" && input[currentIndex] % 2 == 0)
            {
                tempList.Add(input[currentIndex]);
                count--;
            }
            else if (command == "odd" && input[currentIndex] % 2 != 0)
            {
                tempList.Add(input[currentIndex]);
                count--;
            }

            currentIndex--;
        }

        if (tempList.Count == 0)
        {
            Console.WriteLine("[]");
        }
        else
        {
            tempList.Reverse();
            Console.WriteLine("[{0}]", string.Join(", ", tempList));
        }
    }

    private static void GetFirstElements(int[] input, BigInteger count, string command)
    {
        if (count > input.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        List<int> tempList = new List<int>();

        int currentIndex = 0;
        while (count > 0 && currentIndex < input.Length)
        {
            if (command == "even" && input[currentIndex] % 2 == 0)
            {
                tempList.Add(input[currentIndex]);
                count--;
            }
            else if (command == "odd" && input[currentIndex] % 2 != 0)
            {
                tempList.Add(input[currentIndex]);
                count--;
            }

            currentIndex++;
        }

        if (tempList.Count == 0)
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.WriteLine("[{0}]", string.Join(", ", tempList));
        }
    }

    private static void GetIndexOfMinElement(int[] input, string command)
    {
        int maxElement = int.MaxValue;
        bool found = false;
        int index = -1;

        if (command == "odd")
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0 && input[i] <= maxElement)
                {
                    maxElement = input[i];
                    index = i;
                    found = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0 && input[i] <= maxElement)
                {
                    maxElement = input[i];
                    index = i;
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(index);
        }
    }

    private static void GetIndexOfMaxElement(int[] input, string command)
    {
        int maxElement = int.MinValue;
        bool found = false;
        int index = -1;

        if (command == "odd")
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0 && input[i] >= maxElement)
                {
                    maxElement = input[i];
                    index = i;
                    found = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0 && input[i] >= maxElement)
                {
                    maxElement = input[i];
                    index = i;
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(index);
        }
    }

    private static void ExecuteExchange(int[] input, BigInteger exchangeIndex)
    {
        if (exchangeIndex >= input.Length || exchangeIndex < 0)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        if (exchangeIndex == input.Length - 1)
        {
            return;
        }

        int[] temp = new int[input.Length];

        for (BigInteger i = exchangeIndex + 1, j = 0; i < temp.Length; i++, j++)
        {
            temp[(int)j] = input[(int)i];
        }

        for (BigInteger i = input.Length - exchangeIndex - 1, j = 0; i < temp.Length; i++, j++)
        {
            temp[(int)i] = input[(int)j];
        }

        for (int i = 0; i < temp.Length; i++)
        {
            input[i] = temp[i];
        }
    }
}

