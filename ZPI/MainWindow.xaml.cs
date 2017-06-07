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

            for(int i = 0; i < stateNames.Count; i++)
            {
                listView.Items.Add(new TableItem { State = stateNames[i] , AfterTaxation = 100.00, MarkUp = 1});
            }
            
        }

        private void chooseProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chooseProductFromList.Items.Clear();
            List<String> prod = new List<String>();
            for (int i = 0; i < Product.products.Count; i++)
            {
                if (Product.products[i].Type == (ProductType)chooseProductType.SelectedIndex)
                {
                    prod.Add(Product.products[i].Name);
                }
            }

            for (int i = 0; i < prod.Count; i++)
            {
                ProductComboBoxItem item = new ProductComboBoxItem();
                item.Text = prod[i];
                item.Value = i;
                chooseProductFromList.Items.Add(item);
            }
            chooseProductFromList.SelectedIndex = 0;
        }

        private void priceBaseGotFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceBase.Text == "cena bazowa")
                inputPriceBase.Text = "";
        }

        private void priceEndGotFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text == "cena koncowa")
                inputPriceEnd.Text = "";
        }

        private void priceBaseLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceBase.Text.Replace(" ", "") == "")
                inputPriceBase.Text = "cena bazowa";
        }

        private void priceEndLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text.Replace(" ", "") == "")
                inputPriceEnd.Text = "cena koncowa";
        }
    }
}
