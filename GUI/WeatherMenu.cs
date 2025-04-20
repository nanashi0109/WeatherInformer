using System;
using System.Drawing;
using System.Windows.Forms;
using Weather;
using WeatherInformer.WidgetFactory;
using WeatherInformerGUI;

namespace WeatherInformer.GUI
{
    public partial class WeatherMenu : Form, IWeatherSubscriber
    {
        private ThemeSwitcher _themeSwitcher;
        private IWidgetFactory _factory;

        private Label _temperature;
        private Label _feelsLike;
        private Label _humidity;
        private Label _pressure;

        public WeatherMenu(ThemeSwitcher themeSwitcher, IWeatherPublisher weatherPublisher)
        {
            _factory = themeSwitcher.GetFactory;
            _themeSwitcher = themeSwitcher;

            InitializeComponent();

            SetDefaultSettings();

            CreateWidgets();

            weatherPublisher.AddListener(this);
        }

        private void SetDefaultSettings()
        {
            var size = new Size(300, 200);
            Size = size;
            MaximumSize = size;
            MinimumSize = size;

            MaximizeBox = false;
            MinimizeBox = false;

            _factory.SetTheme(this);
            _themeSwitcher.AddWidget(this);
        }

        private void CreateWidgets()
        {
            _temperature = _factory.CreateLabel(new Size(100, 20), new Point(20, 20));
            SubscribeWidget(_temperature);
            
            _feelsLike = _factory.CreateLabel(new Size(100, 20), new Point(150, 20));
            SubscribeWidget(_feelsLike);
            
            _humidity = _factory.CreateLabel(new Size(100, 20), new Point(20, 50));
            SubscribeWidget(_humidity);
            
            _pressure = _factory.CreateLabel(new Size(100, 20), new Point(150, 50));
            SubscribeWidget(_pressure);
        }

        private void SubscribeWidget(Control widget)
        {
            _themeSwitcher.AddWidget(widget);
            Controls.Add(widget);
        }

        public void Update(WeatherMessage message)
        {
            _temperature.Text = $"Temperature: {message.Temperature} C";
            _feelsLike.Text = $"Feels like: {message.FeelsLike} C";
            _humidity.Text = $"Humidity: {message.Humidity} %";
            _pressure.Text = $"Pressure: {message.Pressure} Pa";
        }

        private void WeatherMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
