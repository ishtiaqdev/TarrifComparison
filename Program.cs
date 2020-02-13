using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TarrifComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter annual consumption in kWh/year to calculate Annual Cost.");
            var consumption = int.Parse(Console.ReadLine());
            CalculationModel calculationModel = new CalculationModel();
            List<IProduct> products = calculationModel.GetProducts(consumption);

            foreach(Product pro in products)
            {
                Console.WriteLine("Name: " + pro.ProductName + ", Annual Cost: " + pro.AnnualCost);
            }
            Console.ReadLine();

        }
    }
}
