
using System.Collections.Generic;

namespace App1
{
    class Product
    {

        public static Dictionary<ProductType, string> productTypeStrings = new Dictionary<ProductType, string>()
        {
            { ProductType.Groceries, "Groceries" },
            { ProductType.PreparedFood, "Prepared food" },
            { ProductType.PrescriptionDrug, "Prescription drug" },
            { ProductType.NonPrescriptionDrug, "Non-prescription drug" },
            { ProductType.Clothing, "Clothing" }
        };
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private ProductType type;

        public ProductType Type
        {
            get
            {
                return type;
            }
        }
        private double price;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = Price;
            }
        }

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

        public double PriceBeforeTax(StateData state)
        {
            double tax = state.Tax(type) / 100;
            return price / (1 + tax);
        }
        public double PriceAfterDiscount(double discount, StateData state)
        {
            return PriceAfterTax(state) - discount;
        }
    }
}
