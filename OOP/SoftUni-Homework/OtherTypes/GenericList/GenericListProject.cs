using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    class GenericListProject
    {
        static void Main(string[] args)
        {
            GenericList<int> listOne = new GenericList<int>();
            GenericList<int> listTwo = new GenericList<int>();
            listOne.Add(5);
            listOne.Add(2);
            listOne.Add(3);
            listOne.Add(4);

            listTwo.Add(55);
            listTwo.Add(55);
            listTwo.Add(55);
            listTwo.Add(75);

            GenericList<int> listThree = listOne + listTwo;
            Console.WriteLine(listThree);
            Console.WriteLine(listThree.Min());
            Console.WriteLine(listThree.Max());
        }
    }
}
