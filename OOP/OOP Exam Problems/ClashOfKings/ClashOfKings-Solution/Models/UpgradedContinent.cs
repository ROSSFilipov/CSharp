using ClashOfKings.Contracts;
using ClashOfKings.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models
{
    public class UpgradedContinent : Westeros
    {
        public UpgradedContinent()
            : base()
        {
        }

        public override void Update()
        {
            for (int i = 0; i < this.Houses.Count; i++)
            {
                if (this.Houses[i].ControlledCities.Count() >= 10 && this.Houses[i] is House)
                {
                    GreatHouse temp = new GreatHouse(this.Houses[i].Name, this.Houses[i].TreasuryAmount);
                    foreach (ICity city in this.Houses[i].ControlledCities)
                    {
                        temp.AddCityToHouse(city);
                    }

                    this.Houses[i] = temp;
                }
                else if (this.Houses[i].ControlledCities.Count() < 5 && this.Houses[i] is GreatHouse)
                {
                    House temp = new House(this.Houses[i].Name, this.Houses[i].TreasuryAmount);
                    foreach (ICity city in this.Houses[i].ControlledCities)
                    {
                        temp.AddCityToHouse(city);
                    }

                    this.Houses[i] = temp;
                }
            }

            base.Update();
        }

        public override string Print()
        {
            return base.Print();
        }
    }
}
