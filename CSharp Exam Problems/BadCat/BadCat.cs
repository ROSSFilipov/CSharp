using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BadCat
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        LinkedList<int> numbers = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            string[] currentLine = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int numOne = int.Parse(currentLine[0]);
            int numTwo = int.Parse(currentLine[3]);
            string command = currentLine[2];

            ExecuteCommand(numbers, numOne, numTwo, command);
        }

        Console.WriteLine(string.Join("", numbers));
    }

    private static void ExecuteCommand(LinkedList<int> numbers, int numOne, int numTwo, string command)
    {
        if (numbers.Count == 0)
        {
            numbers.AddLast(numTwo);
        }

        if (!numbers.Contains(numTwo))
        {
            bool isAdded = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                var temp = numbers.ElementAt(i);
                if (temp > numTwo)
                {
                    LinkedListNode<int> node = numbers.Find(temp);
                    numbers.AddBefore(node, numTwo);
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                numbers.AddLast(numTwo);
            }
        }

        if (numbers.Contains(numOne))
        {
            return;
        }

        LinkedListNode<int> current = numbers.Find(numTwo);

        if (command == "before")
        {
            bool isAdded = false;
            for (int i = 0; i < numbers.IndexOf(numTwo); i++)
            {
                var temp = numbers.ElementAt(i);
                if (temp > numOne)
                {
                    LinkedListNode<int> node = numbers.Find(temp);
                    numbers.AddBefore(node, numOne);
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                numbers.AddBefore(current, numOne);
            }
        }
        else
        {
            bool isAdded = false;
            for (int i = numbers.IndexOf(numTwo) + 1; i < numbers.Count - 1; i++)
            {
                var temp = numbers.ElementAt(i);
                if (temp > numOne)
                {
                    LinkedListNode<int> node = numbers.Find(temp);
                    numbers.AddBefore(node, numOne);
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                numbers.AddLast(numOne);
            }
        }
    }
}

public static class Extensions
{
    public static int IndexOf(this LinkedList<int> list, int node)
    {
        int index = -1;

        for (int i = 0; i < list.Count; i++)
        {
            if (list.ElementAt(i) == node)
            {
                index = i;
                break;
            }
        }

        return index;
    }
}



