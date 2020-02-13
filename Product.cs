using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarrifComparison
{
    class Product : IProduct // Product class implementing IProduct interface
    {
        private string _ProductName;
        [Column(Storage = "_ProductName")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }

        private double _AnnualCost;
        [Column(Storage = "_AnnualCost")]
        public double AnnualCost
        {
            get
            {
                return this._AnnualCost;
            }
            set
            {
                this._AnnualCost = value;
            }
        }

        private string _UsageType;
        [Column(Storage = "_AnnualCost")]
        public string UsageType
        {
            get
            {
                return this._UsageType;
            }
            set
            {
                this._UsageType = value;
            }
        }
    }
}
