using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start;
            int end;
            int[] array = new int[10];

            while (true)
            {
                ReadStartNumber(out start);

                ReadEndNumber(start, out end);

                Console.WriteLine("Please enter 10 numbers in the range [{0}...{1}].", start, end);
                for (int i = 0; i < 10; i++)
                {
                    array[i] = ReadNumber(start, end, array);
                }

                Console.WriteLine("The numbers are: [{0}]", string.Join(", ", array));
                break;
            }
        }

        private static void ReadStartNumber(out int start)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the starting number:");
                    bool validStart = int.TryParse(Console.ReadLine(), out start);

                    if (!validStart)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

        private static void ReadEndNumber(int start, out int end)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the end number:");
                    bool validEnd = int.TryParse(Console.ReadLine(), out end);

                    if (!validEnd)
                    {
                        throw new FormatException();
                    }

                    if (end < start)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The end number should be equal or bigger than the start number!");
                }
            }
        }

        private static int ReadNumber(int start, int end, int[] array)
        {
            int currentNumber;

            while (true)
            {
                try
                {
                    bool validCurrentNumber = int.TryParse(Console.ReadLine(), out currentNumber);

                    if (!validCurrentNumber)
                    {
                        throw new FormatException();
                    }

                    if (currentNumber < start || currentNumber > end)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid integer number!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The number you entered is out of range!");
                }
            }

            return currentNumber;
        }
    }
}
