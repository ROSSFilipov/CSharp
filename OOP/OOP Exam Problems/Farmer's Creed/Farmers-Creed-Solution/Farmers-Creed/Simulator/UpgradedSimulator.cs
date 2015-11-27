using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Simulator
{
    public class UpgradedSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0].ToLower();

            switch (action)
            {
                case "create":
                    {
                        base.ProcessInput(input);
                    }
                    break;
                case "add":
                    {
                        base.ProcessInput(input);
                    }
                    break;
                case "status":
                    {
                        base.ProcessInput(input);
                    }
                    break;
                case "exploit":
                    {
                        string type = inputCommands[1].ToLower();
                        string id = inputCommands[2];
                        switch (type)
                        {
                            case "animal":
                                {
                                    IProductProduceable producer = farm.GetAnimalProducer(id);
                                    this.farm.Exploit(producer);
                                }
                                break;
                            case "plant":
                                {
                                    IProductProduceable producer = farm.GetPlantProducer(id);
                                    this.farm.Exploit(producer);
                                }
                                break;
                            default:
                                {
                                    throw new NotImplementedException();
                                }
                        }
                    }
                    break;
                case "feed":
                    {
                        this.farm.Feed(inputCommands[1], inputCommands[2], int.Parse(inputCommands[3]));
                    }
                    break;
                case "water":
                    {
                        this.farm.Water(inputCommands[1]);
                    }
                    break;
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "Grain":
                    {
                        base.AddObjectToFarm(inputCommands);
                    }
                    break;
                case "CherryTree":
                    {
                        Plant currentPlant = UnitFactory.ProducePlant(id, type);
                        this.farm.AddPlant(currentPlant);
                    }
                    break;
                case "TobaccoPlant":
                    {
                        Plant currentPlant = UnitFactory.ProducePlant(id, type);
                        this.farm.AddPlant(currentPlant);
                    }
                    break;
                case "Cow":
                    {
                        Animal currentPlant = UnitFactory.ProduceAnimal(id, type);
                        this.farm.AddAnimal(currentPlant);
                    }
                    break;
                case "Swine":
                    {
                        Animal currentPlant = UnitFactory.ProduceAnimal(id, type);
                        this.farm.AddAnimal(currentPlant);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
