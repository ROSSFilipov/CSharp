using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestZigzagSubsequence
{
    class LongestZigzagSubsequence
    {
        static void Main(string[] args)
        {
            //int[] sequence = new int[] { 24, 5, 31, 3, 3, 342, 51, 114, 52, 55, 56, 58 };
            int[] sequence = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            LinkedList<int> longestZigZagSequenceFirstCase = new LinkedList<int>();

            FindLongestSequenceFirstCase(sequence, longestZigZagSequenceFirstCase);

            LinkedList<int> longestZigZagSequenceSecondCase = new LinkedList<int>();

            FindLongestSequenceSecondCase(sequence, longestZigZagSequenceSecondCase);

            Console.WriteLine(string.Join(" ", longestZigZagSequenceFirstCase));
            Console.WriteLine(string.Join(" ", longestZigZagSequenceSecondCase));
        }

        private static void FindLongestSequenceSecondCase(int[] sequence, LinkedList<int> longestZigZagSequence)
        {
            int arraySize = sequence.Length;
            int[] path = new int[arraySize];
            int[] length = new int[arraySize];

            int maxLength = 0;
            int index = -1;

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (length[j] % 2 != 0 && sequence[i] > sequence[j] && length[j] != 0 && length[j] >= length[i])
                    {
                        path[i] = j;
                        length[i] = length[j];
                    }
                    else if (length[j] % 2 == 0 && sequence[i] < sequence[j] && length[j] != 0 && length[j] >= length[i])
                    {
                        path[i] = j;
                        length[i] = length[j];
                    }
                }

                length[i]++;

                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    index = i;
                }
            }

            for (int i = 0; i < maxLength; i++)
            {
                longestZigZagSequence.AddFirst(sequence[index]);
                index = path[index];
            }
        }

        private static void FindLongestSequenceFirstCase(int[] sequence, LinkedList<int> longestZigZagSequence)
        {
            int arraySize = sequence.Length;
            int[] path = new int[arraySize];
            int[] length = new int[arraySize];

            int maxLength = 0;
            int index = -1;

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (length[j] % 2 != 0 && sequence[i] < sequence[j] && length[j] != 0 && length[j] >= length[i])
                    {
                        path[i] = j;
                        length[i] = length[j];
                    }
                    else if (length[j] % 2 == 0 && sequence[i] > sequence[j] && length[j] != 0 && length[j] >= length[i])
                    {
                        path[i] = j;
                        length[i] = length[j];
                    }
                }

                length[i]++;

                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    index = i;
                }
            }

            for (int i = 0; i < maxLength; i++)
            {
                longestZigZagSequence.AddFirst(sequence[index]);
                index = path[index];
            }
        }
    }
}
