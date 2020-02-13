using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace TarrifComparison
{
    class CalculationModel
    {
        private readonly int _basicTarrif = 0;
        private readonly int _packagedAmount = 0;
        private readonly int _packagedUsageQuantity = 0;

        public CalculationModel()
        {
            //initializing values in class constructor based on configurable values
            _basicTarrif = Convert.ToInt32(ConfigurationManager.AppSettings["basicTarrif"]);
            _packagedAmount = Convert.ToInt32(ConfigurationManager.AppSettings["packagedAmount"]);
            _packagedUsageQuantity = Convert.ToInt32(ConfigurationManager.AppSettings["packagedUsageQuantity"]);
        }

        public List<IProduct> GetProducts(int consumption)
        {
            List<IProduct> products = BuildUpProducts(consumption);
            return products;
        }

        private List<IProduct> BuildUpProducts(int _consumption)
        {
            List<IProduct> products = new List<IProduct>();
            
            Product productA = new Product();
            productA.ProductName = "basic electricity tariff";
            productA.UsageType = "basic";
            productA.AnnualCost = CalculateAnnualCost(productA.UsageType, _consumption); //calculating annual cost in €/year

            Product productB = new Product();
            productB.ProductName = "Packaged tariff";
            productB.UsageType = "package";
            productB.AnnualCost = CalculateAnnualCost(productB.UsageType, _consumption); //calculating annual cost in €/year

            products.Add(productA);
            products.Add(productB);
            products = products.OrderBy(s => s.AnnualCost).ToList(); //sorting in ascending order

            return products;
        }

        private int CalculateAnnualCost(string usageType = "basic", int consumption = 0)
        {
            int annualCost = 0;
            if(usageType == "basic")
            {
                int baseCost = _basicTarrif * 12; // base cost by multiplying basic tarrif with 12 months
                int consumptionCost = (consumption * 22) / 100; //consumption kWh/year * 22 cent/kWh then dividing by 100 to convert from cents to Euros = € consumption costs
                annualCost = baseCost + consumptionCost;
            }
            else if(usageType == "package")
            {
                int extraConsumption = 0;
                int packagedCost = 0;
                int extraConsumptionCost = 0;
                
                if (consumption > _packagedUsageQuantity)
                {
                    extraConsumption = consumption - _packagedUsageQuantity;
                }

                packagedCost = _packagedAmount;
                extraConsumptionCost = (extraConsumption * 30) / 100; // extra consumtion kWh * 30 cent / kWh then dividing by 100 to convert from cents to Euros = total € additional consumption costs

                annualCost = packagedCost + extraConsumptionCost;
            }
            return annualCost;
        }

    }
}
