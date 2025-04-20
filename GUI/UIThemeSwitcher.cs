using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeatherInformer.WidgetFactory;

namespace WeatherInformerGUI
{
    public class UIThemeSwitcher
    {
        private List<Button> _themeSwitchers;
        private List<Control> _widgets;

        private IWidgetFactory _widgetFactory;

        public UIThemeSwitcher(IWidgetFactory widgetFactory)
        {
            _widgetFactory = widgetFactory;
            _widgets = new List<Control>();
            _themeSwitchers = new List<Button>();
        }

        public void AddWidget(Control widget)
        {
            if (_widgets.Contains(widget))
                return;

            _widgets.Add(widget);
        }

        public void AddThemeSwitcher(Button switcher)
        {
            switcher.Click += SwitchTheme;
            _themeSwitchers.Add(switcher);  

            var text = GetTextForSwitcher();
            SetTextForSwitcherElement(switcher, text);
        }

        private void SwitchTheme(object sender, EventArgs e)
        {
            if (_widgetFactory is DarkWidgetFactory)
                _widgetFactory = new LightWidgetFactory();
            else
                _widgetFactory = new DarkWidgetFactory();

            SetTextForSwitchers();
            UpdateThemesOnWidgets();
        }

        private void SetTextForSwitchers()
        {
            var text = GetTextForSwitcher();

            foreach (Button switcher in _themeSwitchers)
                SetTextForSwitcherElement(switcher, text);
        }

        private string GetTextForSwitcher()
        {
            string text;
            if (_widgetFactory is DarkWidgetFactory)
                text = "D";
            else
                text = "L";

            return text;
        }

        private void SetTextForSwitcherElement(Button switcher, string text) 
            => switcher.Text = text;

        private void UpdateThemesOnWidgets()
        {
            foreach (var widget in _widgets)
                _widgetFactory.SetTheme(widget);
        }

    }
}
