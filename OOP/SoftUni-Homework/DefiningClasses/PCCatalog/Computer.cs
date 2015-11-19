using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    public class Computer
    {
        private string model;

        private decimal price;

        private Component GPU;

        private Component motherboard;

        private Component processor;

        private const string BASE_MODEL = "missing information";

        private const decimal BASE_PRICE = 0m;

        public Computer(
            string model, decimal price,
            string gpuName, decimal gpuPrice,
            string motherboardName, decimal motherboardPrice,
            string processorName, decimal processorPrice)
        {
            this.ModelSet = model;
            this.PriceSet = price;
            this.MotherboardSet = new Component(motherboardName, motherboardPrice);
            this.GPUSet = new Component(gpuName, gpuPrice);
            this.ProcessorSet = new Component(processorName, processorPrice);
        }

        public Computer(string model, decimal price)
        {
            this.ModelSet = model;
            this.PriceSet = price;
            this.MotherboardSet = new Component();
            this.GPUSet = new Component();
            this.ProcessorSet = new Component();
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
                    throw new ArgumentException("Invalid computer name information!");
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
                    throw new ArgumentException("Invalid computer price information!");
                }
                this.price = value;
            }
        }

        public Component GPUSet
        {
            get
            {
                return this.GPU;
            }
            set
            {
                this.GPU = value;
            }
        }

        public Component MotherboardSet
        {
            get
            {
                return this.motherboard;
            }
            set
            {
                this.motherboard = value;
            }
        }

        public Component ProcessorSet
        {
            get
            {
                return this.processor;
            }
            set
            {
                this.processor = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Computer:\n\tModel: {0}\n\tPrice: {1:F2} BGN\n\tGraphic card:\n{2}\n\tMotherboard:\n{3}\n\tProcessor:n{4}\n", 
                this.ModelSet, this.PriceSet, this.GPUSet, this.MotherboardSet, this.ProcessorSet);
        }

        public void Display()
        {
            Console.WriteLine(this.ToString());
            decimal totalPrice = this.GPUSet.PriceSet + this.MotherboardSet.PriceSet + this.ProcessorSet.PriceSet;
            Console.WriteLine("Total price of all components: {0:F2} BGN.", totalPrice);
        }
    }
}
