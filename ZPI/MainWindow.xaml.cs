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
            if (inputPriceBase.Text == "price without taxes")
                inputPriceBase.Text = "";
        }

        private void PriceEndGotFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text == "end price")
                inputPriceEnd.Text = "";
        }

        private void PriceBaseLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceBase.Text.Replace(" ", "") == "")
                inputPriceBase.Text = "price without taxes";
        }

        private void PriceEndLostFocus(object sender, RoutedEventArgs e)
        {
            if (inputPriceEnd.Text.Replace(" ", "") == "")
                inputPriceEnd.Text = "end price";
        }

        private void ExampleProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                inputPriceBase.Text = ((ProductComboBoxItem)chooseProductFromList.SelectedItem).Value.Price.ToString();
                fillTextView();
            }
            catch (Exception) { };
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            fillTextView();
        }

        private void fillTextView()
        {
            listView.Items.Clear();
            Double priceAfterTax = 0.0;
            Double difference = 0.0;
            List<String> stateNames = new List<String>();
            stateNames = StateData.getStateNames();
            for (int i = 0; i < stateNames.Count; i++)
            {
                priceAfterTax = ((ProductComboBoxItem)chooseProductFromList.SelectedItem).Value.PriceAfterTax(StateData.info((State)i));
                if(!inputPriceEnd.Text.Equals("end price"))
                {
                    difference = Convert.ToDouble(inputPriceEnd.Text) - priceAfterTax;
                }
                Console.WriteLine(difference);
                listView.Items.Add(new TableItem { State = stateNames[i], AfterTaxation = priceAfterTax, MarkUp = difference });
            }
        }
    }
}
