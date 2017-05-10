
using System.Collections.Generic;

namespace ZPI
{
    class Product
    {
        public static List<Product> products = new List<Product>
        {
            new Product("Banana", ProductType.Groceries, 1),
            new Product("Cheese", ProductType.Groceries, 5),
            new Product("Vicodin", ProductType.PrescriptionDrug, 11),
            new Product("Valium", ProductType.PrescriptionDrug, 15),
            new Product("Tylenol", ProductType.NonPrescriptionDrug, 10),
            new Product("Claritin", ProductType.NonPrescriptionDrug, 15),
            new Product("Jeans", ProductType.Clothing, 20),
            new Product("Shoes", ProductType.Clothing, 30)
        };

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

        private double endPrice;
        private double EndPrice
        {
            get
            {
                return endPrice;
            }
            set
            {
                endPrice = EndPrice;
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

        public double MarkUp(StateData state)
        {
            return PriceAfterTax(state) - endPrice;
             
        }

        public double PriceAfterDiscount(double discount, StateData state)
        {
            return PriceAfterTax(state) - discount;
        }
    }
}
