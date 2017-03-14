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

namespace FMSE1
{
    /// <summary>
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CityGotFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TxtBoxFocus(cityBox);
        }

        private void CountryGotFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TxtBoxFocus(countryBox);
        }

        private void TxtBoxFocus(TextBox txtbx)
        {
            if (txtbx.Text == "Enter City..." || txtbx.Text == "Enter Country...")
            {
                txtbx.Text = "";
            }
        }

        private void SetDestination_Clicked(object sender, RoutedEventArgs e)
        {
            String city = cityBox.Text;
            String country = countryBox.Text;

            //MapView.SetPositionByKeywords("Ratisbon, Germany");
            Application.Current.Windows.OfType<MainApplicationWindow>().First<MainApplicationWindow>().setNewMapPositionByKeywords(city, country);
        }
    }
}
