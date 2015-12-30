using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CommandInterpreter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] final = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        string command = Console.ReadLine();
        while (command != "end")
        {
            string[] array = command.Split();

            if (array[0] == "reverse")
            {
                int start = int.Parse(array[2]);
                int count = int.Parse(array[4]);
                if (start < 0 || start >= final.Length || (count + start > final.Length) || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    ReverseArray(final, start, count);
                }
            }
            else if (array[0] == "sort")
            {
                int start = int.Parse(array[2]);
                int count = int.Parse(array[4]);
                if (start < 0 || start >= final.Length || (count + start > final.Length) || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    SelectionSortArray(final, start, count);
                }
            }
            else if (array[0] == "rollLeft")
            {
                int count = int.Parse(array[1].ToString());
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    RollLeft(final, count);
                }
            }
            else if (array[0] == "rollRight")
            {
                int count = int.Parse(array[1].ToString());
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    RollRight(final, count);
                }
            }
            command = Console.ReadLine();
        }
        Console.WriteLine("[" + String.Join(", ", final) + "]");
    }

    private static void RollLeft(string[] final, int count)
    {
        LinkedList<string> tempList = new LinkedList<string>();
        for (int i = 0; i < final.Length; i++)
        {
            tempList.AddLast(final[i]);
        }
        int counter = 0;
        string x = String.Empty;
        while (counter < count % final.Length)
        {
            x = tempList.First();
            tempList.RemoveFirst();
            tempList.AddLast(x);
            counter++;
        }
        int j = 0;
        foreach (var item in tempList)
        {
            final[j] = item;
            j++;
        }
    }

    private static void RollRight(string[] final, int count)
    {
        LinkedList<string> tempList = new LinkedList<string>();
        for (int i = 0; i < final.Length; i++)
        {
            tempList.AddLast(final[i]);
        }
        int counter = 0;
        string x = String.Empty;
        while (counter < count % final.Length)
        {
            x = tempList.Last();
            tempList.RemoveLast();
            tempList.AddFirst(x);
            counter++;
        }
        int j = 0;
        foreach (var item in tempList)
        {
            final[j] = item;
            j++;
        }
    }

    private static void SelectionSortArray(string[] final, int start, int count)
    {
        for (int i = start; i < start + count - 1; i++)
        {
            string x = String.Empty;
            for (int j = i + 1; j < start + count; j++)
            {
                if (String.Compare(final[i], final[j]) > 0)
                {
                    x = final[j];
                    final[j] = final[i];
                    final[i] = x;
                }
            }
        }
    }

    private static void ReverseArray(string[] final, int start, int count)
    {
        string[] tempArray = new string[count];
        for (int i = 0; i < count; i++)
        {
            tempArray[i] = final[i + start];
        }
        Array.Reverse(tempArray);
        for (int i = 0; i < tempArray.Length; i++)
        {
            final[i + start] = tempArray[i];
        }
    }
}

