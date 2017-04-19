using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<String> stateInfo = new List<String>();
            stateInfo = StateData.getStateNames();
            for (int i = 0; i < stateInfo.Count; i++)
            {
                StateComboBoxItem item = new StateComboBoxItem();
                item.Text = stateInfo[i];
                item.Value = (State)i;
                inputChoice1.Items.Add(item);
            }
            inputChoice1.SelectedIndex = 0;
            /*
            for (int i = 0; i < stateInfo.Count; i++)
            {
                Product item = new StateComboBoxItem();
                item.Text = stateInfo[i];
                item.Value = (State)i;
                inputChoice2.Items.Add(item

            }
            inputChoice2.SelectedIndex = 0;*/
        }

        private void inputChoice1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
