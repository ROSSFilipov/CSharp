using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Digits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            TakeInput(matrix, n);

            //int zeroCounter = CountZeroDigits(matrix, n);

            int oneCounter = CountOneDigits(matrix, n);

            int twoCounter = CountOTwoDigits(matrix, n);

            int threeCounter = CountThreeDigits(matrix, n);

            int fourCounter = CountFourDigits(matrix, n);

            int fiveCounter = CountFiveDigits(matrix, n);

            int sixCounter = CountSixDigits(matrix, n);

            int sevenCounter = CountSevenDigits(matrix, n);

            int eightCounter = CountEightDigits(matrix, n);

            int nineCounter = CountNineDigits(matrix, n);

            int sum =
                oneCounter * 1 +
                twoCounter * 2 +
                threeCounter * 3 +
                fourCounter * 4 +
                fiveCounter * 5 +
                sixCounter * 6 +
                sevenCounter * 7 +
                eightCounter * 8 +
                nineCounter * 9;

            Console.WriteLine(sum);
        }

        //private static int CountZeroDigits(int[,] matrix, int n)
        //{
        //    int sum = 0;

        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {

        //        }
        //    }

        //    return sum;
        //}

        private static int CountOneDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j + 2] == 1 &&
                        matrix[i + 1, j + 1] == 1 &&
                        matrix[i + 1, j + 2] == 1 &&
                        matrix[i + 2, j] == 1 &&
                        matrix[i + 2, j + 2] == 1 &&
                        matrix[i + 3, j + 2] == 1 &&
                        matrix[i + 4, j + 2] == 1)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountOTwoDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 1; j < n - 2; j++)
                {
                    if (matrix[i, j + 1] == 2 &&
                        matrix[i + 1, j] == 2 &&
                        matrix[i + 1, j + 2] == 2 &&
                        matrix[i + 2, j + 2] == 2 &&
                        matrix[i + 3, j + 1] == 2 &&
                        matrix[i + 4, j] == 2 &&
                        matrix[i + 4, j + 1] == 2 &&
                        matrix[i + 4, j + 2] == 2)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountThreeDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 3 &&
                        matrix[i, j + 1] == 3 &&
                        matrix[i, j + 2] == 3 &&
                        matrix[i + 1, j + 2] == 3 &&
                        matrix[i + 2, j + 1] == 3 &&
                        matrix[i + 2, j + 2] == 3 &&
                        matrix[i + 3, j + 2] == 3 &&
                        matrix[i + 4, j] == 3 &&
                        matrix[i + 4, j + 1] == 3 &&
                        matrix[i + 4, j + 2] == 3)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountFourDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 4 &&
                        matrix[i, j + 2] == 4 &&
                        matrix[i + 1, j] == 4 &&
                        matrix[i + 1, j + 2] == 4 &&
                        matrix[i + 2, j] == 4 &&
                        matrix[i + 2, j + 1] == 4 &&
                        matrix[i + 2, j + 2] == 4 &&
                        matrix[i + 3, j + 2] == 4 &&
                        matrix[i + 4, j + 2] == 4)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountFiveDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 5 &&
                        matrix[i, j + 1] == 5 &&
                        matrix[i, j + 2] == 5 &&
                        matrix[i + 1, j] == 5 &&
                        matrix[i + 2, j] == 5 &&
                        matrix[i + 2, j + 1] == 5 &&
                        matrix[i + 2, j + 2] == 5 &&
                        matrix[i + 3, j + 2] == 5 &&
                        matrix[i + 4, j] == 5 &&
                        matrix[i + 4, j + 1] == 5 &&
                        matrix[i + 4, j + 2] == 5)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountSixDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 6 &&
                        matrix[i, j + 1] == 6 &&
                        matrix[i, j + 2] == 6 &&
                        matrix[i + 1, j] == 6 &&
                        matrix[i + 2, j] == 6 &&
                        matrix[i + 2, j + 1] == 6 &&
                        matrix[i + 2, j + 2] == 6 &&
                        matrix[i + 3, j] == 6 &&
                        matrix[i + 3, j + 2] == 6 &&
                        matrix[i + 4, j] == 6 &&
                        matrix[i + 4, j + 1] == 6 &&
                        matrix[i + 4, j + 2] == 6)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountSevenDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 7 &&
                        matrix[i, j + 1] == 7 &&
                        matrix[i, j + 2] == 7 &&
                        matrix[i + 1, j + 2] == 7 &&
                        matrix[i + 2, j + 1] == 7 &&
                        matrix[i + 3, j + 1] == 7 &&
                        matrix[i + 4, j + 1] == 7)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountEightDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 8 &&
                        matrix[i, j + 1] == 8 &&
                        matrix[i, j + 2] == 8 &&
                        matrix[i + 1, j] == 8 &&
                        matrix[i + 1, j + 2] == 8 &&
                        matrix[i + 2, j + 1] == 8 &&
                        matrix[i + 3, j] == 8 &&
                        matrix[i + 3, j + 2] == 8 &&
                        matrix[i + 4, j] == 8 &&
                        matrix[i + 4, j + 1] == 8 &&
                        matrix[i + 4, j + 2] == 8)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static int CountNineDigits(int[,] matrix, int n)
        {
            int sum = 0;

            for (int i = 0; i < n - 4; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    if (matrix[i, j] == 9 &&
                        matrix[i, j + 1] == 9 &&
                        matrix[i, j + 2] == 9 &&
                        matrix[i + 1, j] == 9 &&
                        matrix[i + 1, j + 2] == 9 &&
                        matrix[i + 2, j + 1] == 9 &&
                        matrix[i + 2, j + 2] == 9 &&
                        matrix[i + 3, j + 2] == 9 &&
                        matrix[i + 4, j] == 9 &&
                        matrix[i + 4, j + 1] == 9 &&
                        matrix[i + 4, j + 2] == 9)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static void TakeInput(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currentLine = Console.ReadLine()
                    .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentLine[j];
                }
            }
        }
    }
}
