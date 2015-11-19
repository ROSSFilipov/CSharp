using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int n;

                    bool validNumber = int.TryParse(Console.ReadLine(), out n);

                    if (!validNumber)
                    {
                        throw new ArgumentException();
                    }

                    if (n < 0)
                    {
                        throw new ArithmeticException();
                    }

                    double x = Math.Sqrt(n);
                    Console.WriteLine("{0:F2}", x);
                    break;
                }
                catch (ArithmeticException)
                {
                    Console.Error.WriteLine("The number cannot be negative!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter a valid integer number!");
                }
                finally
                {
                    Console.WriteLine("Finally block executed!");
                }
            }
            Console.WriteLine("Over!");
        }
    }
}
