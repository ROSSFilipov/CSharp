namespace Longest_Common_Subsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Enter the first string:");
            var firstStr = Console.ReadLine();
            Console.WriteLine("Enter the second string:");
            var secondStr = Console.ReadLine();

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int rows = firstStr.Length + 1;
            int cols = secondStr.Length + 1;
            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix, firstStr, secondStr, rows, cols);

            string sequence = BacktrackSequence(matrix, firstStr, secondStr);

            return sequence;
        }

        private static void FillMatrix(int[,] matrix, string firstStr, string secondStr, int rows, int cols)
        {
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }
        }

        private static string BacktrackSequence(int[,] matrix, string firstStr, string secondStr)
        {
            LinkedList<char> charSequence = new LinkedList<char>();
            int i = matrix.GetLength(0) - 1;
            int j = matrix.GetLength(1) - 1;

            while (i > 0 && j > 0)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    charSequence.AddFirst(firstStr[i - 1]);
                    i--;
                    j--;
                }
                else if (matrix[i,j] == matrix[i - 1, j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            return string.Join("", charSequence);
        }
    }
}
