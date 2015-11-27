namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;
    using System.Text;
    using System.Linq;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants;
        private List<Animal> animals;
        private List<Product> products;

        public Farm(string id)
            : base(id)
        {
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
            this.products = new List<Product>();
        }

        public IEnumerable<Plant> Plants
        {
            get 
            {
                return this.plants;
            }
        }

        public IEnumerable<Animal> Animals
        {
            get 
            {
                return this.animals;
            }
        }

        public IEnumerable<Product> Products
        {
            get 
            {
                return this.products;
            }
        }

        public void AddProduct(Product productToBeAdded)
        {
            Product currentProduct = this.products.Find(x => x.Id == productToBeAdded.Id);

            if (currentProduct == null)
            {
                this.products.Add(productToBeAdded);
            }
            else
            {
                currentProduct.Quantity += productToBeAdded.Quantity;
            }
        }

        public void AddPlant(Plant plantToBeAdded)
        {
            Plant currentPlant = this.plants.Find(x => x.Id == plantToBeAdded.Id);

            if (currentPlant != null)
            {
                throw new InvalidOperationException("Plant with this ID already exists!");
            }

            this.plants.Add(plantToBeAdded);
        }

        public void AddAnimal(Animal animalToBeAdded)
        {
            Animal currentAnimal = this.animals.Find(x => x.Id == animalToBeAdded.Id);

            if (currentAnimal != null)
            {
                throw new InvalidOperationException("Animal with this ID already exists!");
            }

            this.animals.Add(animalToBeAdded);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            this.AddProduct(productProducer.GetProduct());
        }

        public void Feed(string animalToBeFed, string edibleProduct, int productQuantity)
        {
            Animal currentAnimal = this.animals.Find(x => x.Id == animalToBeFed);
            Product currentProduct = this.products.Find(x => x.Id == edibleProduct);

            if (currentAnimal == null)
            {
                throw new ArgumentNullException("Animal not found!");
            }

            if (currentProduct == null)
            {
                throw new ArgumentNullException("Product not found!");
            }

            currentAnimal.Eat(currentProduct as IEdible, productQuantity);
            currentProduct.Quantity -= productQuantity;
        }

        public void Water(string plant)
        {
            Plant currentPlant = this.plants.Find(x => x.Id == plant);

            if (currentPlant == null)
            {
                throw new ArgumentNullException("Plant not found!");
            }

            currentPlant.Water();
        }

        public IProductProduceable GetPlantProducer(string plantToBeFound)
        {
            IProductProduceable producer = this.plants.Find(x => x.Id == plantToBeFound);

            if (producer == null)
            {
                throw new ArgumentNullException("Plant producer not found!");
            }

            return producer;
        }

        public IProductProduceable GetAnimalProducer(string animalToBeFound)
        {
            IProductProduceable producer = this.animals.Find(x => x.Id == animalToBeFound);

            if (producer == null)
            {
                throw new ArgumentNullException("Animal producer not found!");
            }

            return producer;
        }

        public void UpdateFarmState()
        {
            foreach (Plant currentPlant in this.plants)
            {
                if (currentPlant.IsAlive)
                {
                    if (currentPlant.HasGrown)
                    {
                        currentPlant.Wither();
                    }
                    else if (!currentPlant.HasGrown)
                    {
                        currentPlant.Grow();
                    } 
                }
            }

            foreach (Animal currentAnimal in this.animals)
            {
                if (currentAnimal.IsAlive)
                {
                    currentAnimal.Starve();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("--{0} {1}", this.GetType().Name, this.Id));

            var aliveAnimals = this.animals
                .Where(x => x.IsAlive)
                .OrderBy(x => x.Id);

            foreach (Animal currentAnimal in aliveAnimals)
            {
                sb.AppendLine(currentAnimal.ToString());
            }

            var alivePlants = this.plants
                .Where(x => x.IsAlive)
                .OrderBy(x => x.Health)
                .ThenBy(x => x.Id);

            foreach (Plant currentPlant in alivePlants)
            {
                sb.AppendLine(currentPlant.ToString());
            }

            var sortedProducts = this.products
                .OrderBy(x => x.ProductType)
                .ThenByDescending(x => x.Quantity)
                .ThenBy(x => x.Id);

            foreach (Product currentProduct in sortedProducts)
            {
                sb.AppendLine(currentProduct.ToString());
            }

            return sb.ToString();
        }
    }
}
