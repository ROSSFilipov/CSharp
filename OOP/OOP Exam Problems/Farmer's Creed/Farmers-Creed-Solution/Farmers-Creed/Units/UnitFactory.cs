using FarmersCreed.Units.Animals;
using FarmersCreed.Units.ConstantValues;
using FarmersCreed.Units.Plants;
using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public static class UnitFactory
    {
        public static Product ProduceProduct(string originalID, ProductType productType)
        {
            string productID = originalID + PlantValues.PlantProductIDIndex;
            Product currentProduct;
            switch (productType)
            {
                case ProductType.Grain:
                    {
                        currentProduct = new Food(productID);
                        LoadGrainProductValues(currentProduct as Food);
                        return currentProduct as Food;
                    }
                case ProductType.Tobacco:
                    {
                        currentProduct = new Product(productID);
                        LoadTobaccoProductValues(currentProduct);
                        return currentProduct;
                    }
                case ProductType.Cherry:
                    {
                        currentProduct = new Food(productID);
                        LoadCherryProductValues(currentProduct as Food);
                        return currentProduct;
                    }
                case ProductType.Milk:
                    {
                        currentProduct = new Food(productID);
                        LoadMilkProductValues(currentProduct as Food);
                        return currentProduct as Food;
                    }
                case ProductType.PorkMeat:
                    {
                        currentProduct = new Food(productID);
                        LoadPorkMeatProductValues(currentProduct as Food);
                        return currentProduct as Food;
                    }
                default:
                    {
                        throw new NotImplementedException("Unknown product type " + productType);
                    }
            }
        }

        public static Plant ProducePlant(string id, string type)
        {
            switch (type)
            {
                case "CherryTree":
                    {
                        Plant currentPlant = new CherryTree(id);
                        LoadCherryTreeValues(currentPlant as CherryTree);
                        return currentPlant;
                    }
                case "TobaccoPlant":
                    {
                        Plant currentPlant = new TobaccoPlant(id);
                        LoadTobaccoPlantValues(currentPlant as TobaccoPlant);
                        return currentPlant;
                    }
                default:
                    {
                        throw new NotImplementedException("Unknown plant type " + type);
                    }
            }
        }

        private static void LoadCherryTreeValues(CherryTree currentPlant)
        {
            currentPlant.Health = FoodPlantValues.CherryTreeHealth;
            currentPlant.GrowTime = FoodPlantValues.CherryTreeGrowTime;
        }

        private static void LoadTobaccoPlantValues(TobaccoPlant currentPlant)
        {
            currentPlant.Health = PlantValues.TobaccoPlantHealth;
            currentPlant.GrowTime = PlantValues.TobaccoPlantGrowTime;
        }

        public static Animal ProduceAnimal(string id, string type)
        {
            switch (type)
            {
                case "Cow":
                    {
                        Animal currentAnimal = new Cow(id);
                        LoadCowValues(currentAnimal);
                        return currentAnimal;
                    }
                case "Swine":
                    {
                        Animal currentAnimal = new Swine(id);
                        LoadSwineValues(currentAnimal);
                        return currentAnimal;
                    }
                default:
                    {
                        throw new NotImplementedException("Unknown animal type " + type);
                    }
            }
        }

        private static void LoadCowValues(Animal currentAnimal)
        {
            currentAnimal.Health = AnimalValues.CowHealth;
        }

        private static void LoadSwineValues(Animal currentAnimal)
        {
            currentAnimal.Health = AnimalValues.SwineHealth;
        }

        private static void LoadGrainProductValues(Food currentProduct)
        {
            currentProduct.Quantity = FoodPlantValues.GrainQuantity;
            currentProduct.ProductType = ProductType.Grain;
            currentProduct.HealthEffect = FoodPlantValues.GrainHealthEffect;
            currentProduct.FoodType = FoodType.Organic;
        }

        private static void LoadTobaccoProductValues(Product currentProduct)
        {
            currentProduct.Quantity = PlantValues.TobaccoPlantProductQuantity;
        }

        private static void LoadCherryProductValues(Food currentProduct)
        {
            currentProduct.Quantity = FoodPlantValues.CherryTreeProductQuantity;
            currentProduct.FoodType = FoodType.Organic;
            currentProduct.ProductType = ProductType.Cherry;
            currentProduct.HealthEffect = FoodPlantValues.CherryTreeProductHealthEffect;
        }

        private static void LoadMilkProductValues(Food currentProduct)
        {
            currentProduct.Quantity = AnimalValues.CowProductQuantity;
            currentProduct.FoodType = FoodType.Organic;
            currentProduct.HealthEffect = AnimalValues.CowProductHealthEffect;
        }

        private static void LoadPorkMeatProductValues(Food currentProduct)
        {
            currentProduct.Quantity = AnimalValues.SwineProductQuantity;
            currentProduct.FoodType = FoodType.Meat;
            currentProduct.HealthEffect = AnimalValues.SwineProductHealthEffect;
        }
    }
}
