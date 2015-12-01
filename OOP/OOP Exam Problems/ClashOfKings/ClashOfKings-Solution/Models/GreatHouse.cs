using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models
{
    public class GreatHouse : House
    {
        private const int MinHouseNameLength = 2;
        private const int MaxHouseNameLength = 15;

        private const string EmptyHouseNameErrorMessage = "House name cannot be null";
        private const string InvalidHouseNameErrorMessage =
            "House name should be between {0} and {1} symbols long and contain only Latin letters";
        private const string CityNotFoundErrorMessage = "Specified city does not exist or is not controlled by house {0}";
        private const string InsufficientUpgradeFundsErrorMessage = "House {0} has insufficient funds to upgrade {1}";

        private static readonly string HouseNamePattern = string.Format("[a-zA-Z]{{{0},{1}}}", MinHouseNameLength, MaxHouseNameLength);

        private decimal treasuryAmount;

        public GreatHouse(string name, decimal initialTreasuryAmount)
            : base(name, initialTreasuryAmount)
        {
            this.TreasuryAmount = initialTreasuryAmount;
        }

        public override decimal TreasuryAmount
        {
            get
            {
                return this.treasuryAmount;
            }
            set
            {
                this.treasuryAmount = value;
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override void UpgradeCity(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("city", CityNotFoundErrorMessage);
            }

            city.Upgrade();
            this.TreasuryAmount -= city.UpgradeCost;
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Great House {0}:{1}", this.Name, Environment.NewLine);
            result.AppendFormat("-Treasury Amount: {0:F1}{1}", this.TreasuryAmount, Environment.NewLine);

            if (this.ControlledCities.Any())
            {
                result.AppendFormat(
                "-Controlled Cities ({0}): {1}",
                this.ControlledCities.Count(),
                string.Join(", ", this.ControlledCities.Select(c => c.Name)));
            }
            else
            {
                result.AppendFormat("-No Cities Controlled");
            }

            return result.ToString();
        }
    }
}
