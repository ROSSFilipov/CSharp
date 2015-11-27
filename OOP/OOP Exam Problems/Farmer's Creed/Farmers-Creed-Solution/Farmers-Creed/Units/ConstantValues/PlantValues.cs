using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public static class PlantValues
    {
        private static int BasePlantGrowSpeed = 1;
        private static int BasePlantWitherSpeed = 1;
        private static int BasePlantWaterValue = 2;
        private static string BasePlantProductIDIndex = "Product";

        private static int BaseTobaccoPlantWaterValue = 2 * BasePlantWaterValue;
        private static int BaseTobaccoPlantHealth = 14;
        private static int BaseTobaccoPlantGrowTime = 4;
        private static int BaseTobaccoPlantProductQuantity = 10;

        public static int PlantGrowSpeed
        {
            get
            {
                return BasePlantGrowSpeed;
            }
        }

        public static int PlantWitherSpeed
        {
            get
            {
                return BasePlantWitherSpeed;
            }
        }

        public static int PlantWaterValue
        {
            get
            {
                return BasePlantWaterValue;
            }
        }

        public static int TobaccoPlantWaterValue
        {
            get
            {
                return BaseTobaccoPlantWaterValue;
            }
        }

        public static int TobaccoPlantHealth
        {
            get
            {
                return BaseTobaccoPlantHealth;
            }
        }

        public static int TobaccoPlantGrowTime
        {
            get
            {
                return BaseTobaccoPlantGrowTime;
            }
        }

        public static string PlantProductIDIndex
        {
            get
            {
                return BasePlantProductIDIndex;
            }
        }

        public static int TobaccoPlantProductQuantity
        {
            get
            {
                return BaseTobaccoPlantProductQuantity;
            }
        }
    }
}
