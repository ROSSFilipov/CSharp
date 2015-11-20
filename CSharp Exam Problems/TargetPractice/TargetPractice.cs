using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split();
            string snake = Console.ReadLine();
            string[] shoot = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            string[,] matrix = new string[rows,cols];

            FillMatrix(matrix, snake, rows, cols);

            ExecuteBomb(matrix, shoot, rows, cols);

            SelectionSort(matrix, rows, cols);

            PrintMatrix(matrix);
        }

        private static void SelectionSort(string[,] matrix, int rows, int cols)
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

        private static void ExecuteBomb(string[,] matrix, string[] shoot, int rows, int cols)
        {
            int impactRow = int.Parse(shoot[0]);
            int impactCol = int.Parse(shoot[1]);
            int impactRadius = int.Parse(shoot[2]);

            string centre = matrix[impactRow, impactCol];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - impactRow, 2) + Math.Pow(j - impactCol, 2));
                    if (distance <= impactRadius)
                    {
                        matrix[i, j] = " ";
                    }
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(string[,] matrix, string snake, int rows, int cols)
        {
            int counter = 0;
            for (int i = rows - 1, index = 0; i >= 0; i--,index++)
            {
                if (index % 2 == 0)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[counter % snake.Length].ToString();
                        counter++;
                    }
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = snake[counter % snake.Length].ToString();
                        counter++;
                    }
                }
            }
        }
    }
}
