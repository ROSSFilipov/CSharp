namespace FarmersCreed.Interfaces
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Units;

    public interface IFarm 
    {
        IEnumerable<Plant> Plants { get; }

        IEnumerable<Animal> Animals { get; }

        IEnumerable<Product> Products { get; }

        void AddProduct(Product product);

        void AddAnimal(Animal animal);

        void AddPlant(Plant plant);

        IProductProduceable GetPlantProducer(string id);

        IProductProduceable GetAnimalProducer(string id);

        void Exploit(IProductProduceable productProducer);

        void Feed(string animal, string edibleProduct, int productQuantity);

        void Water(string plant);

        void UpdateFarmState();
    }
}
