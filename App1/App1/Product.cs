using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Product
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private ProductType type;
        private double price;

        public Product(string name, ProductType type, double price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public double PriceAfterTax(StateData state)
        {
            double tax = state.Tax(type) / 100;
            return price * (1 + tax);
        }
        public double PriceAfterDiscount()
        {
            return price;
        }
    }
}
