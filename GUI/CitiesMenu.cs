using System;
using System.Drawing;
using System.Windows.Forms;
using Tools;
using Weather;
using WeatherInformer.WidgetFactory;
using WeatherInformerGUI;

namespace WeatherInformer.GUI
{
    public partial class CitiesMenu : Form
    {
        private IWidgetFactory _widgetFactory;
        private IWeatherData _weatherData;

        private ThemeSwitcher _themeSwitcher;

        public CitiesMenu(IWidgetFactory widgetFactory, IWeatherData weatherData)
        {
            _widgetFactory = widgetFactory;

            _themeSwitcher = new ThemeSwitcher(widgetFactory);
            _weatherData = weatherData;
            
            InitializeComponent();

            SetDefaultFormSettings();

            CreateWidgets();
        }

        private void SetDefaultFormSettings()
        {
            var size = new Size(300, 200);
            Size = size;
            MaximumSize = size;
            MinimumSize = size;
            
            MaximizeBox = false;
            MinimizeBox = false;

            _themeSwitcher.AddWidget(this);
        }

        #region Creating widgets
        private void CreateWidgets()
        {
            CreateHeader();

            CreateThemeToggleButton();

            CreateButtonForOpenNewWindow();
            CreateUpdateInfoButton();
        }

        private void CreateHeader()
        {
            var header = _widgetFactory.CreateLabel(new Size(150, 20), new Point(80, 0));
            header.Text = UIConstants.HEADER;

            SubscribeWidget(header);
        }

        private void CreateThemeToggleButton()
        {
            var themeToggle = _widgetFactory.CreateButton(new Size(20, 20), new Point(255, 5));

            _themeSwitcher.AddThemeSwitcher(themeToggle);
            SubscribeWidget(themeToggle);
        }

        private void CreateButtonForOpenNewWindow()
        {
            var button = _widgetFactory.CreateButton(new Size(100, 50), new Point(100, 50));
            button.Text = UIConstants.OPEN_WINDOW;

            button.Click += (object sender, EventArgs e) => OpenNewWeatherMenu();

            SubscribeWidget(button);
        }

        private void CreateUpdateInfoButton()
        {
            var button = _widgetFactory.CreateButton(new Size(100, 25), new Point(100, 105));
            button.Text = UIConstants.UPDATE_INFO;

            button.Click += (object sender, EventArgs e) => _weatherData.UpdateData();
            SubscribeWidget(button);
        }

        private void SubscribeWidget(Control widget)
        {
            _themeSwitcher.AddWidget(widget);
            Controls.Add(widget);
        }
        #endregion

        private void OpenNewWeatherMenu()
        {
            var weatherMenu = new WeatherMenu(_themeSwitcher, _weatherData);
            weatherMenu.Show();
        }

        private void WeatherInformerMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
