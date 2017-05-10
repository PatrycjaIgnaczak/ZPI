using App1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<String> stateNames = new List<String>();
            stateNames = StateData.getStateNames();

            for (int i = 0; i < Product.productTypeStrings.Count; i++)
            {
                ProductTypeComboBoxItem item = new ProductTypeComboBoxItem();
                item.Text = Product.productTypeStrings[(ProductType)i];
                item.Value = (ProductType)i;
                chooseProductType.Items.Add(item);
            }
            chooseProductType.SelectedIndex = 0;

            listView.Items.Add(new TableItem { State = "Test", AfterTaxation = 100.00, MarkUp = 1});
        }
    }
}
