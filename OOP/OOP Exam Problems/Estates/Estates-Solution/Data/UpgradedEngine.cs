using Estates.Engine;
using Estates.Interfaces;
using Estates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    class UpgradedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "create":
                    return ExecuteCreateCommand(cmdArgs);
                case "status":
                    return ExecuteStatusCommand();
                case "find-sales-by-location":
                    return base.ExecuteCommand(cmdName, cmdArgs);
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                default:
                    throw new NotImplementedException("Unknown command: " + cmdName);
            }
        }

        private string ExecuteFindRentsByPriceCommand(decimal minPrice, decimal maxPrice)
        {
            var rents = this.Offers
                .Where(x => x is IRentOffer)
                .Where(x => (x as IRentOffer).PricePerMonth >= minPrice && (x as IRentOffer).PricePerMonth <= maxPrice)
                .OrderBy(x => (x as IRentOffer).PricePerMonth)
                .ThenBy(x => x.Estate.Name);
            return this.FormatQueryResults(rents);
        }

        protected string ExecuteFindRentsByLocationCommand(string location)
        {
            var rents = this.Offers
                .Where(x => x.Estate.Location == location && x.Type == OfferType.Rent)
                .OrderBy(x => x.Estate.Name);
            return this.FormatQueryResults(rents);
        }
    }
}
