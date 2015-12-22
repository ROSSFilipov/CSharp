using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needles
{
    class Needles
    {
        static List<int> indexes = new List<int>();

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] needles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InsertionSort(numbers, needles);

            Console.WriteLine(string.Join(" ", indexes));
        }

        private static void InsertionSort(int[] numbers, int[] needles)
        {
            for (int i = 0; i < needles.Length; i++)
            {
                bool found = false;
                for (int j = numbers.Length - 1; j >= 0; j--)
                {
                    if (numbers[j] < needles[i] && numbers[j] != 0)
                    {
                        indexes.Add(j + 1);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    indexes.Add(0); 
                }
            }
        }
    }
}
