using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class State
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private double groceries;
        private double preparedFood;
        private double prescriptionDrug;
        private double nonPrescriptedDrug;
        private double clothing;

        public double Tax(ProductType type)
        {
            switch (type)
            {
                case ProductType.Clothing:
                    return clothing;
                case ProductType.Groceries:
                    return groceries;
                case ProductType.NonPrescriptionDrug:
                    return nonPrescriptedDrug;
                case ProductType.PreparedFood:
                    return preparedFood;
                case ProductType.PrescriptionDrug:
                    return prescriptionDrug;
                default:
                    throw new Exception();
            }
        }
    }
}
