using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using static Antonucci.Federico._5h.WStatiom.JSonMeteo;

namespace Antonucci.Federico._5h.WStatiom
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(
                new Uri(@"http://api.wunderground.com/api/6236e40cf12325d6/conditions/q/IT/" + txtCitta.Text + ".json"));
            RootObject Meteo = JsonConvert.DeserializeObject<RootObject>(result);
            lblTemperatura.Content = Meteo.current_observation.temp_c.ToString();
            lblUmidità.Content = Meteo.current_observation.relative_humidity.ToString();
            lblDescrizione.Content = Meteo.current_observation.display_location.city.ToString() + "," + Meteo.current_observation.display_location.country.ToString();
            lblAltitudine.Content = Meteo.current_observation.display_location.elevation.ToString();
            lblLongitudine.Content = Meteo.current_observation.display_location.longitude.ToString();
            lblLatitudine.Content = Meteo.current_observation.display_location.latitude.ToString();
            lblUmidità.Content = Meteo.current_observation.relative_humidity.ToString();
            lblVelocità.Content = Meteo.current_observation.wind_mph.ToString();
            imgMeteo.Source = new BitmapImage(new Uri(Meteo.current_observation.icon_url));
        }
    }
}
