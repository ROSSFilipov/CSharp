using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextGravity
{
    class TextGravity
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int x = input.Length % n;
            int final = input.Length / n;
            if (x != 0)
            {
                final++;
            }
            if (final == 0)
            {
                final = 1;
            }
            string[,] matrix = new string[final,n];
            int counter = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (counter > input.Length - 1)
                    {
                        matrix[i,j] = " ";
                    }
                    else
                    {
                        matrix[i, j] = input[counter % input.Length].ToString();
                        counter++; 
                    }
                }
            }
            Regex pattern = new Regex("\\<|\\>|&|\"|'");

            SelectionSortSolution(matrix, rows, cols);

            //Manual SecurityEscape method
            SecurityEscape(matrix, rows, cols, pattern);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            for (int i = 0; i < rows; i++)
            {
                sb.Append("<tr>");
                for (int j = 0; j < cols; j++)
                {
                    sb.Append("<td>");
                    sb.Append(matrix[i,j]);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            Console.WriteLine(sb.ToString());
        }

        private static void SecurityEscape(string[,] matrix, int rows, int cols, Regex pattern)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pattern.IsMatch(matrix[i, j]))
                    {
                        matrix[i, j] = SecurityElement.Escape(matrix[i, j]);
                    }
                }
            }
        }

        private static void SelectionSortSolution(string[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = rows - 1; j >= 1; j--)
                {
                    for (int h = j - 1; h >= 0; h--)
                    {
                        if (matrix[j, i] == " ")
                        {
                            if (matrix[h, i] != " ")
                            {
                                string x = matrix[j, i];
                                matrix[j, i] = matrix[h, i];
                                matrix[h, i] = x;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
