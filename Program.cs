using Weather;
using System;
using System.Windows.Forms;

namespace WeatherInformer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //var weatherData = new WeatherData();

            //weatherData.UpdateData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
