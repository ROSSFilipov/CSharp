using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Laptop one = new Laptop(
                "Lenovo Yoga 2 Pro", 
                2259.0042342m, 
                "Lenovo", 
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 
                "8GB", 
                "Intel HD Graphics 4400", 
                "128GB SSD", 
                "13.3\" (33.78 cm) – 3200 x 1800 (QHD+) IPS sensor display");
            Laptop two = new Laptop("Dell", 99.99m);
            one.BatterySet = new Battery("Corsair", "34235");
            Console.WriteLine(one);
            Console.WriteLine();
            Console.WriteLine(two);
        }
    }
}
