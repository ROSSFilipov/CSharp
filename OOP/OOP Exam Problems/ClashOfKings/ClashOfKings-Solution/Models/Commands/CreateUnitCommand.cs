﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Models.Armies;
    using ClashOfKings.Models.Armies.AirForce;
    using ClashOfKings.Models.Armies.Cavalry;
    using ClashOfKings.Models.Armies.Infantry;
    using System.Collections;

    [Command]
    public class CreateUnitCommand : Command
    {
        public CreateUnitCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            int numberOfUnits = int.Parse(commandParams[0]);

            if (numberOfUnits < 0)
            {
                throw new ArgumentOutOfRangeException("Number of units should be non-negative");
            }

            ICity currentCity = this.Engine.Continent.GetCityByName(commandParams[2]);

            if (currentCity == null)
            {
                throw new InvalidOperationException();
            }

            IMilitaryUnit currentUnit = this.GetUnitType(commandParams[1]);

            if (currentCity.AvailableUnitCapacity(currentUnit.Type) < numberOfUnits * currentUnit.HousingSpacesRequired)
            {
                throw new InvalidOperationException(string.Format("City {0} does not have enough housing spaces to accommodate {1} units of {2}",
                    currentCity.Name, numberOfUnits, currentUnit.GetType().Name));
            }

            if (currentUnit.TrainingCost * numberOfUnits > currentCity.ControllingHouse.TreasuryAmount)
            {
                throw new InvalidOperationException(string.Format("House {0} does not have enough funds to train {1} units of {2}",
                    currentCity.ControllingHouse.Name, numberOfUnits, currentUnit.GetType().Name));
            }

            var unitCollection = GetUnitCollection(commandParams[1], numberOfUnits);

            currentCity.AddUnits(unitCollection);
            currentCity.ControllingHouse.TreasuryAmount -= currentUnit.TrainingCost * numberOfUnits;

            Console.WriteLine("Successfully added {0} units of {1} to city {2}",
                numberOfUnits, currentUnit.GetType().Name, commandParams[2]);
        }

        private MilitaryUnit[] GetUnitCollection(string type, int numberOfUnits)
        {
            MilitaryUnit[] collection; ;
            switch (type)
            {
                case "FootSoldier":
                    collection = new FootSoldier[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new FootSoldier();
                    }
                    return collection;
                case "SellSword":
                    collection = new SellSword[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new SellSword();
                    }
                    return collection;
                case "Unsullied":
                    collection = new Unsullied[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new Unsullied();
                    }
                    return collection;
                case "Dothraki": 
                    collection = new Dothraki[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new Dothraki();
                    }
                    return collection;
                case "Horseman": 
                collection = new Horseman[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new Horseman();
                    }
                    return collection;
                case "Knight": 
                    collection = new Knight[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new Knight();
                    }
                    return collection;
                case "Dragon": 
                    collection = new Dragon[numberOfUnits];
                    for (int i = 0; i < numberOfUnits; i++)
                    {
                        collection[i] = new Dragon();
                    }
                    return collection;
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }

        private IMilitaryUnit GetUnitType(string type)
        {
            switch (type)
            {
                case "FootSoldier": return new FootSoldier();
                case "SellSword": return new SellSword();
                case "Unsullied": return new Unsullied();
                case "Dothraki": return new Dothraki();
                case "Horseman": return new Horseman();
                case "Knight": return new Knight();
                case "Dragon": return new Dragon();
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }
    }
}
