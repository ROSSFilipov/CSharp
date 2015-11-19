using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class PCCatalog
    {
        static void Main(string[] args)
        {
            Computer one = new Computer("HP", 399.99m);
            Computer two = new Computer("Dell", 499.99m);
            Computer three = new Computer("Apple", 4959.99m);
            Computer four = new Computer("Acer", 899.99m);

            four.MotherboardSet = new Component("GamineOne", 49.99m);
            four.GPUSet = new Component("NVidia", 51m, "970 GTX");
            var collection = new List<Computer>();
            collection.Add(one);
            collection.Add(two);
            collection.Add(three);
            collection.Add(four);

            var sorted = collection.OrderByDescending(x => x.PriceSet);
            foreach (var item in sorted)
            {
                item.Display();
            }

            Console.WriteLine(one);
        }
    }
}
