using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarrifComparison
{
    interface IProduct
    {
        string ProductName { get; set; }
        double AnnualCost { get; set; }
    }
}
