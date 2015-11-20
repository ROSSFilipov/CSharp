using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    public class Dragon
    {
        public string Name { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public string Color { get; set; }

        public Dragon(string color, string name, int damage, int health, int armor)
        {
            this.Color = color;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
            this.Name = name;
        }
    }

    public class DragonArmy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dragonArmy = new List<Dragon>();

            for (int i = 0; i < n; i++)
            {
                string[] currentDragon = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                string color = currentDragon[0];
                string name = currentDragon[1];
                int damage = currentDragon[2] == "null" ? 45 : int.Parse(currentDragon[2]);
                int health = currentDragon[3] == "null" ? 250 : int.Parse(currentDragon[3]);
                int armor = currentDragon[4] == "null" ? 10 : int.Parse(currentDragon[4]);

                Dragon dragon = new Dragon(color, name, damage, health, armor);
                
                if (!dragonArmy.ContainsDragon(dragon))
                {
                    dragonArmy.Add(dragon);
                }
                else
                {
                    int index = dragonArmy.IndexOfDragon(dragon);
                    dragonArmy[index].Name = name;
                    dragonArmy[index].Color = color;
                    dragonArmy[index].Damage = damage;
                    dragonArmy[index].Health = health;
                    dragonArmy[index].Armor = armor;
                }
            }

            var sortedDragons = dragonArmy.OrderBy(y => y.Name).GroupBy(x => x.Color);

            foreach (var item in sortedDragons)
            {
                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", 
                    item.Key,
                    item.Average(x => x.Damage),
                    item.Average(x => x.Health),
                    item.Average(x => x.Armor));

                foreach (var dragon in item)
                {
                    Console.WriteLine("-{0}->damage:{1}, health:{2}, armor:{3}", 
                        dragon.Name, 
                        dragon.Damage, 
                        dragon.Health, 
                        dragon.Armor);
                }
            }
        }
    }
     
    public static class Extensions
    {
        public static bool ContainsDragon(this List<Dragon> dragonList, Dragon other)
        {
            bool containsDragon = false;
            for (int i = 0; i < dragonList.Count; i++)
            {
                if (dragonList[i].Name == other.Name && dragonList[i].Color == other.Color)
                {
                    containsDragon = true;
                    break;
                }
            }

            return containsDragon;
        }

        public static int IndexOfDragon(this List<Dragon> dragonList ,Dragon other)
        {
            int index = 0;

            for (int i = 0; i < dragonList.Count; i++)
            {
                if (dragonList[i].Name == other.Name && dragonList[i].Color == other.Color)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
