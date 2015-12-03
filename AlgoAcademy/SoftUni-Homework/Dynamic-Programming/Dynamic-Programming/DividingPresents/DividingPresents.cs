using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividingPresents
{
    class DividingPresents
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            //int[] numbers = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

            Array.Sort(numbers);

            LinkedList<int> firstPack = new LinkedList<int>();
            LinkedList<int> secondPack = new LinkedList<int>();

            int firstSum = 0;
            int secondSum = 0;
            DistributePresents(firstPack, secondPack, numbers, ref firstSum, ref secondSum);

            Console.WriteLine(string.Join(" ", firstPack));
            Console.WriteLine(string.Join(" ", secondPack));
            Console.WriteLine("Difference: {0}", Math.Abs(firstSum - secondSum));
        }

        private static void DistributePresents(LinkedList<int> firstPack, LinkedList<int> secondPack, int[] numbers, ref int firstSum, ref int secondSum)
        {
            bool[] used = new bool[numbers.Length];

            int difference = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    firstPack.AddFirst(numbers[i]);
                    firstSum += numbers[i];
                    used[i] = true;
                    difference += numbers[i];

                    for (int j = i; j >= 0; j--)
                    {
                        if (difference <= 0)
                        {
                            break;
                        }

                        if (!used[j])
                        {
                            secondPack.AddFirst(numbers[j]);
                            secondSum += numbers[j];
                            difference -= numbers[j];
                            used[j] = true;
                        }
                    }
                }
            }
        }
    }
}
