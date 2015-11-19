using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    public class Battery
    {
        private string model;

        private string batterylife;

        private const string BASE_MODEL = "missing information";

        private const string BASE_LIFE = "missing information";

        public Battery() : this (BASE_MODEL, BASE_LIFE)
        {

        }

        public Battery(string model, string life)
        {
            this.ModelSet = model;
            this.BatteryLifeSet = life;
        }

        public string ModelSet
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Equals(" "))
                {
                    throw new ArgumentException("Invalid battery model information!");
                }
                this.model = value;
            }
        }

        public string BatteryLifeSet
        {
            get
            {
                return this.batterylife;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Equals(" "))
                {
                    throw new ArgumentException("Invalid battery life information!");
                }
                this.batterylife = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Battery model: {0}, battery life: {1}", this.ModelSet, this.BatteryLifeSet);
        }
    }
}
