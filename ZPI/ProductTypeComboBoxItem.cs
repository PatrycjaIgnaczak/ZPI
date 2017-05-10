using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class ProductTypeComboBoxItem
    {
        public string Text { get; set; }
        public ProductType Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
