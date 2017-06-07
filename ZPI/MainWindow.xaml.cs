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
            
            

            foreach (var pType in Product.productTypeStrings)
            {
                chooseProductType.Items.Add(new ProductTypeComboBoxItem() {
                    Text = pType.Value,
                    Value = pType.Key
                });
            }
            chooseProductType.SelectedIndex = 0;

            
        }

        private void ChooseProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chooseProductFromList.Items.Clear();

            foreach (var product in Product.products.Where(product => product.Type.Equals(((ProductTypeComboBoxItem)chooseProductType.SelectedValue).Value)))
            {
                chooseProductFromList.Items.Add(new ProductComboBoxItem()
                {
                    Text = product.Name,
                    Value = product
                });
            }

            chooseProductFromList.SelectedIndex = 0;
        }

        private void PriceBaseGotFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceBase.Text == "cena bazowa")
                inputPriceBase.Text = "";
        }

        private void PriceEndGotFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text == "cena koncowa")
                inputPriceEnd.Text = "";
        }

        private void PriceBaseLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceBase.Text.Replace(" ", "") == "")
                inputPriceBase.Text = "cena bazowa";
        }

        private void PriceEndLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text.Replace(" ", "") == "")
                inputPriceEnd.Text = "cena koncowa";
        }

        private void ExampleProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                inputPriceBase.Text = ((ProductComboBoxItem)chooseProductFromList.SelectedItem).Value.Price.ToString();
            }
            catch (Exception) { };
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            List<String> stateNames = new List<String>();
            stateNames = StateData.getStateNames();
            for (int i = 0; i < stateNames.Count; i++)
            {
                listView.Items.Add(new TableItem { State = stateNames[i], AfterTaxation = 100.00, MarkUp = 1 });
            }
        }
    }
}
