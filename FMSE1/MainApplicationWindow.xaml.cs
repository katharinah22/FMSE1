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
using System.Windows.Shapes;
using System.Xml;

namespace FMSE1
{
    /// <summary>
    /// Interaktionslogik für MainApplicationWindow.xaml
    /// </summary>
    public partial class MainApplicationWindow : Window
    {
        public MainApplicationWindow()
        {
            InitializeComponent();

            MapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            MapView.SetPositionByKeywords("Ratisbon, Germany");
            MapView.ShowCenter = false;
        }

        private void testWindowButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Console.WriteLine("Drag Completed!");
            String contentWith = ContentColumn.Width.ToString();
            String mapWith = MapColumn.Width.ToString();
            contentWith = contentWith.Remove(contentWith.Length - 1);
            mapWith = mapWith.Remove(mapWith.Length - 1);
            Console.WriteLine("contentWidth: " + contentWith + " mapWidth: " + mapWith);

            myMenu.Width = XmlConvert.ToDouble(contentWith) - 20;
        }

        public void setNewMapPositionByKeywords(String city, String country)
        {
            MapView.SetPositionByKeywords(city + ", " + country);
        }
    }
}
