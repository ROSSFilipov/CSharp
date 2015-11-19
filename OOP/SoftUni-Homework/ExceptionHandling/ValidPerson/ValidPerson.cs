using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPerson
{
    class ValidPerson
    {
        static void Main(string[] args)
        {
            List<Person> collection = new List<Person>();

            while (true)
            {
                Person tempPerson = new Person();

                ReadFirstName(tempPerson);

                ReadLastName(tempPerson);

                ReadAge(tempPerson);

                collection.Add(tempPerson);
                Console.WriteLine("Person added!");

                break;
            }
        }

        private static void ReadFirstName(Person tempPerson)
        {
            while (true)
            {
                Console.WriteLine("Please enter person's first name:");
                try
                {
                    string currentName = Console.ReadLine();
                    tempPerson.FirstName = currentName;
                    break;
                }
                catch (ArgumentNullException ex)
                {
                    Console.Error.WriteLine("Exception: {0}", ex.Message);
                }
            }
        }

        private static void ReadLastName(Person tempPerson)
        {
            while (true)
            {
                Console.WriteLine("Please enter person's last name:");
                try
                {
                    string currentName = Console.ReadLine();
                    tempPerson.LastName = currentName;
                    break;
                }
                catch (ArgumentNullException ex)
                {
                    Console.Error.WriteLine("Exception: {0}", ex.Message);
                }
            }
        }

        private static void ReadAge(Person tempPerson)
        {
            while (true)
            {
                Console.WriteLine("Please enter person's age:");
                try
                {
                    int temp = int.Parse(Console.ReadLine());
                    tempPerson.Age = temp;
                    break;
                }
                catch (ArgumentNullException ex)
                {
                    Console.Error.WriteLine("Exception: {0}", ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.Error.WriteLine("Exception: {0}.", ex.Message);
                }
            }
        }
    }
}
