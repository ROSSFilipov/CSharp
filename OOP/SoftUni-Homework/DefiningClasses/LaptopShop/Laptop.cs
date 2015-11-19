using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    public class Laptop
    {
        private string model;

        private decimal price;

        private string manifacturer;

        private string processor;

        private string RAM;

        private string graphicCard;

        private string HDD;

        private string screen;

        private Battery battery;

        private const string BASE_MODEL = "missing information";

        private const decimal BASE_PRICE = 0m;

        private const string BASE_MANIFACTURER = "missing information";

        private const string BASE_PROCESSOR = "missing information";

        private const string BASE_RAM = "missing information";

        private const string BASE_GRAPHIC_CARD = "missing information";

        private const string BASE_HDD = "missing information";

        private const string BASE_SCREEN = "missing information";

        public Laptop(string model, decimal price)
            : this(model, price, BASE_MANIFACTURER, BASE_PROCESSOR, BASE_RAM, BASE_GRAPHIC_CARD, BASE_HDD, BASE_SCREEN)
        {

        }

        public Laptop(string model, decimal price, string manifacturer, string processor, string ram, string graphiccard, string hdd, string screen)
        {
            this.model = model;
            this.PriceSet = price;
            this.ManifacturerSet = manifacturer;
            this.ProcessorSet = processor;
            this.RAMSet = ram;
            this.GPUSet = graphiccard;
            this.HDDSet = hdd;
            this.ScreenSet = screen;
            this.BatterySet = new Battery();
        }

        public string ModelSet
        {
            get 
            {
                return this.model;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid model information!");
                }
                this.model = value;
            }
        }

        public decimal PriceSet
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Invalid price information!");
                }
                this.price = value;
            }
        }

        public string ManifacturerSet
        {
            get
            {
                return this.manifacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid manifacturer information!");
                }
                this.manifacturer = value;
            }
        }

        public string ProcessorSet
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid processor information!");
                }
                this.processor = value;
            }
        }

        public string RAMSet
        {
            get
            {
                return this.RAM;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid RAM information!");
                }
                this.RAM = value;
            }
        }

        public string GPUSet
        {
            get
            {
                return this.graphicCard;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Graphic Card information!");
                }
                this.graphicCard = value;
            }
        }

        public string HDDSet
        {
            get
            {
                return this.HDD;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid HDD information!");
                }
                this.HDD = value;
            }
        }

        public string ScreenSet
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid screen information!");
                }
                this.screen = value;
            }
        }

        public Battery BatterySet
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Laptop:\n\tModel: {0}\n\tPrice: {1:F2}\n\tManifacturer: {2}\n\tProcessor: {3}\n\tRAM: {4}\n\tGraphic card: {5}\n\tHDD: {6}\n\tScreen: {7}\n\t\tBattery:\n\t\tBattery model: {8}\n\t\tBattery life: {9}", 
                this.ModelSet, this.PriceSet ,this.ManifacturerSet, this.ProcessorSet, this.RAMSet, this.GPUSet, this.HDDSet, this.ScreenSet, this.BatterySet.ModelSet, this.BatterySet.BatteryLifeSet);
        }
    }
}
