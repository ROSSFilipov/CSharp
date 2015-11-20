using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkosNotebook
{
    internal class Player
    {
        private string name;

        private int age;

        private int win;

        private int loss;

        private List<string> opponents;

        public Player(string name)
            : this()
        {
            this.Name = name;
        }

        public double Rank()
        {
            double rank = (this.Win + 1d) / (this.Loss + 1d);

            return rank;
        }

        public int OpponentsCount()
        {
            return this.opponents.Count;
        }

        public Player()
        {
            this.opponents = new List<string>();
        }

        public string Opponents()
        {
            var newList = this.opponents.OrderBy(x => x, StringComparer.Ordinal);
            return string.Format("{0}", string.Join(", ", newList));
        }

        public void AddOpponent(string name)
        {
            this.opponents.Add(name);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public int Win
        {
            get
            {
                return this.win;
            }
            set
            {
                this.win = value;
            }
        }

        public int Loss
        {
            get
            {
                return this.loss;
            }
            set
            {
                this.loss = value;
            }
        }
    }

    class VladkosNotebook
    {
        static void Main(string[] args)
        {
            var playerCollection = new SortedDictionary<string, Player>();

            TakeInputData(playerCollection);

            bool dataFound = false;
            foreach (KeyValuePair<string, Player> item in playerCollection)
            {
                if (item.Value.Age == 0 || item.Value.Name == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Color: {0}", item.Key);
                    Console.WriteLine("-age: {0}", item.Value.Age);
                    Console.WriteLine("-name: {0}", item.Value.Name);
                    Console.WriteLine("-opponents: {0}", item.Value.OpponentsCount() == 0 ? "(empty)" : item.Value.Opponents());
                    Console.WriteLine("-rank: {0:F2}", item.Value.Rank());
                    dataFound = true;
                }
            }

            if (!dataFound)
            {
                Console.WriteLine("No data recovered.");
            }
        }

        private static void TakeInputData(SortedDictionary<string, Player> playerCollection)
        {
            while (true)
            {
                string currentData = Console.ReadLine();

                if (currentData == "END")
                {
                    break;
                }

                string[] data = currentData.Split('|');
                string color = data[0];
                if (!playerCollection.ContainsKey(color))
                {
                    playerCollection.Add(color, new Player());
                }

                if (data[1] == "name")
                {
                    playerCollection[color].Name = data[2];
                }

                if (data[1] == "win")
                {
                    playerCollection[color].Win++;
                    playerCollection[color].AddOpponent(data[2]);
                }

                if (data[1] == "loss")
                {
                    playerCollection[color].Loss++;
                    playerCollection[color].AddOpponent(data[2]);
                }

                if (data[1] == "age")
                {
                    playerCollection[color].Age = int.Parse(data[2]);
                }
            }
        }
    }
}
