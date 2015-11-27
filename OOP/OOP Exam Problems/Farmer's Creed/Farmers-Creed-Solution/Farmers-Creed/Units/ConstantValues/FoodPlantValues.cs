using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.ConstantValues
{
    public static class FoodPlantValues
    {
        private static int BaseFoodPlantWaterValue = 2;
        private static int BaseFoodPlantWitherSpeed = 2 * PlantValues.PlantWitherSpeed;

        private static int BaseCherryTreeHealth = 14;
        private static int BaseCherryTreeGrowTime = 3;
        private static int BaseCherryTreeProductQuantity = 4;
        private static int BaseCherryTreeProductHealthEffect = 2;

        private static int BaseGrainQuantity = 10;
        private static int BaseGrainHealthEffect = 2;

        public static int FoodPlantWaterValue
        {
            get
            {
                return BaseFoodPlantWaterValue;
            }
        }

        public static int FoodPlantWitherSpeed
        {
            get
            {
                return BaseFoodPlantWitherSpeed;
            }
        }

        public static int CherryTreeHealth
        {
            get
            {
                return BaseCherryTreeHealth;
            }
        }

        public static int CherryTreeGrowTime
        {
            get
            {
                return BaseCherryTreeGrowTime;
            }
        }

        public static int CherryTreeProductQuantity
        {
            get
            {
                return BaseCherryTreeProductQuantity;
            }
        }

        public static int CherryTreeProductHealthEffect
        {
            get
            {
                return BaseCherryTreeProductHealthEffect;
            }
        }

        public static int GrainQuantity
        {
            get
            {
                return BaseGrainQuantity;
            }
        }

        public static int GrainHealthEffect
        {
            get
            {
                return BaseGrainHealthEffect;
            }
        }
    }
}
