using Weather;
using WeatherInformer.GUI; 
using System;
using System.Windows.Forms;
using WeatherInformer.WidgetFactory;

namespace WeatherInformer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var baseWidgetFactory = new LightWidgetFactory();
            var weatherData = new WeatherData();

            Application.Run(new CitiesMenu(baseWidgetFactory, weatherData));
        }
    }
}
