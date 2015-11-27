using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.ConstantValues
{
    public static class AnimalValues
    {
        private static int BaseAnimalStarvationIndex = 1;

        private static int BaseCowHealth = 15;
        private static int BaseCowProductQuantity = 6;
        private static int BaseCowProductHealthEffect = 4;
        private static int BaseCowProductionHealthDecreaseIndex = 2;

        private static int BaseSwineHealth = 20;
        private static int BaseSwineProductQuantity = 1;
        private static int BaseSwineProductHealthEffect = 5;
        private static int BaseSwineProductionHealthDecreaseIndex = 0;
        private static int BaseSwineStarvationIndex = 3 * BaseAnimalStarvationIndex;
        private static int BaseSwineEatIncreaseIndex = 2;

        public static int AnimalStarvationIndex
        {
            get
            {
                return BaseAnimalStarvationIndex;
            }
        }

        public static int CowHealth
        {
            get
            {
                return BaseCowHealth;
            }
        }

        public static int CowProductQuantity
        {
            get
            {
                return BaseCowProductQuantity;
            }
        }

        public static int CowProductHealthEffect
        {
            get
            {
                return BaseCowProductHealthEffect;
            }
        }

        public static int CowProductionHealthDecreaseIndex
        {
            get
            {
                return BaseCowProductionHealthDecreaseIndex;
            }
        }

        public static int SwineHealth
        {
            get
            {
                return BaseSwineHealth;
            }
        }

        public static int SwineProductQuantity
        {
            get
            {
                return BaseSwineProductQuantity;
            }
        }

        public static int SwineProductHealthEffect
        {
            get
            {
                return BaseSwineProductHealthEffect;
            }
        }

        public static int SwineProductionHealthDecreaseIndex
        {
            get
            {
                return BaseSwineProductionHealthDecreaseIndex;
            }
        }

        public static int SwineStarvationIndex
        {
            get
            {
                return BaseSwineStarvationIndex;
            }
        }

        public static int SwineEatIncreaseIndex
        {
            get
            {
                return BaseSwineEatIncreaseIndex;
            }
        }
    }
}
