namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
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
                    if (sequence[j] < sequence[i] && length[i] <= length[j])
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

            int[] finalSequence = new int[maxLength];

            for (int i = maxLength - 1; i >= 0; i--)
            {
                finalSequence[i] = sequence[index];
                index = path[index];
            }

            return finalSequence;
        }
    }
}
