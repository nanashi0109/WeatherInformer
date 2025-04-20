using System;
using System.Drawing;
using System.Windows.Forms;
using Tools;
using WeatherInformer.WidgetFactory;
using WeatherInformerGUI;

namespace WeatherInformer.GUI
{
    public partial class CitiesMenu : Form
    {
        private IWidgetFactory _widgetFactory;
        private UIThemeSwitcher _themeSwitcher;

        public CitiesMenu(IWidgetFactory widgetFactory)
        {
            _themeSwitcher = new UIThemeSwitcher(widgetFactory);
            _widgetFactory = widgetFactory;

            InitializeComponent();
            CreateWidgets();
        }

        #region Createing widgets
        private void CreateWidgets()
        {
            SetDefaultFormSettings();

            CreateHeader();

            CreateThemeToggleButton();
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

        private void CreateHeader()
        {
            var header = _widgetFactory.CreateLabel(new Size(150, 20), new Point(50, 0));
            header.Text = UIConstants.HEADER;

            _themeSwitcher.AddWidget(header);
            Controls.Add(header);
        }

        private void CreateThemeToggleButton()
        {
            var themeToggle = _widgetFactory.CreateButton(new Size(20, 20), new Point(255, 5));

            _themeSwitcher.AddWidget(themeToggle);
            _themeSwitcher.AddThemeSwitcher(themeToggle);
            Controls.Add(themeToggle);
        }
        #endregion

        private void WeatherInformerMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
