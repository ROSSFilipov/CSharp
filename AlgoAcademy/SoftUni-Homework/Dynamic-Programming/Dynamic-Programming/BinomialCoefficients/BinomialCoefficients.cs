using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialCoefficients
{
    class BinomialCoefficients
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int element = int.Parse(Console.ReadLine());

            int[][] pascalTriangle = new int[numberOfRows + 1][];

            FillTriangle(pascalTriangle, numberOfRows);

            Console.WriteLine(pascalTriangle[numberOfRows][element]);
        }

        private static void FillTriangle(int[][] pascalTriangle, int numberOfRows)
        {
            //Hardcoding 1st and 2nd rows of the Pascal's triangle
            pascalTriangle[0] = new int[] { 1 };
            pascalTriangle[1] = new int[] { 1, 1 };

            int collumnCounter = 3;
            for (int i = 2; i <= numberOfRows; i++)
            {
                pascalTriangle[i] = new int[collumnCounter];
                for (int j = 0; j < collumnCounter; j++)
                {
                    if (j == 0 || j == collumnCounter - 1)
                    {
                        pascalTriangle[i][j] = 1;
                    }
                    else
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    }
                }

                collumnCounter++;
            }
        }
    }
}
