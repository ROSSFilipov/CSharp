using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClearingCommands
{
    class ClearingCommands
    {
        static void Main(string[] args)
        {
            List<string> text = TakeInput();

            int size1 = text.Count;
            int size2 = text[0].Length;

            char[,] matrix = new char[size1, size2];

            FillMatrix(text, matrix, size1, size2);

            ClearMatrix(matrix, size1, size2);

            List<string> output = new List<string>();

            for (int i = 0; i < size1; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < size2; j++)
                {
                    sb.Append(matrix[i, j]);
                }
                output.Add(string.Format("<p>" + SecurityElement.Escape(sb.ToString()) + "</p>"));
            }

            foreach (string item in output)
            {
                Console.WriteLine(item);
            }
        }

        private static void ClearMatrix(char[,] matrix, int size1, int size2)
        {
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    switch (matrix[i, j])
                    {
                        case '<': RemoveLeft(matrix, i, j, size1, size2);
                            continue;
                        case '>': RemoveRight(matrix, i, j, size1, size2);
                            continue;
                        case '^': RemoveUp(matrix, i, j, size1, size2);
                            continue;
                        case 'v': RemoveDown(matrix, i, j, size1, size2);
                            continue;
                        default:
                            continue;
                    }
                }
            }
        }

        private static void RemoveLeft(char[,] matrix, int i, int j, int size1, int size2)
        {
            for (int col = j; col >= 0; col--)
            {
                if (matrix[i, col] == '>' || matrix[i, col] == 'v' || matrix[i, col] == '^')
                {
                    return;
                }
                else if (matrix[i, col] == '<')
                {
                    continue;
                }
                else
                {
                    matrix[i, col] = ' ';
                }
            }
        }

        private static void RemoveRight(char[,] matrix, int i, int j, int size1, int size2)
        {
            for (int col = j; col < size2; col++)
            {
                if (matrix[i, col] == '<' || matrix[i, col] == 'v' || matrix[i, col] == '^')
                {
                    return;
                }
                else if (matrix[i, col] == '>')
                {
                    continue;
                }
                else
                {
                    matrix[i, col] = ' ';
                }
            }
        }

        private static void RemoveUp(char[,] matrix, int i, int j, int size1, int size2)
        {
            for (int row = i; row >= 0; row--)
            {
                if (matrix[row, j] == '>' || matrix[row, j] == 'v' || matrix[row, j] == '<')
                {
                    return;
                }
                else if (matrix[row, j] == '^')
                {
                    continue;
                }
                else
                {
                    matrix[row, j] = ' ';
                }
            }
        }

        private static void RemoveDown(char[,] matrix, int i, int j, int size1, int size2)
        {
            for (int row = i; row < size1; row++)
            {
                if (matrix[row, j] == '>' || matrix[row, j] == '<' || matrix[row, j] == '^')
                {
                    return;
                }
                else if (matrix[row, j] == 'v')
                {
                    continue;
                }
                else
                {
                    matrix[row, j] = ' ';
                }
            }
        }

        private static void FillMatrix(List<string> text, char[,] matrix, int size1, int size2)
        {
            for (int i = 0; i < size1; i++)
            {
                string currentLine = text[i];
                for (int j = 0; j < size2; j++)
                {
                    matrix[i, j] = currentLine[j];
                }
            }
        }

        private static List<string> TakeInput()
        {
            List<string> inputList = new List<string>();

            while (true)
            {
                string currentLine = Console.ReadLine();

                if (currentLine == "END")
                {
                    break;
                }

                inputList.Add(currentLine);
            }

            return inputList;
        }
    }
}
