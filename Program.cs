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
            Application.Run(new CitiesMenu(new LightWidgetFactory()));
        }
    }
}
