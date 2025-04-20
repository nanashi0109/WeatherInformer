using System.Drawing;
using System.Windows.Forms;

namespace WeatherInformer.WidgetFactory
{
    public class DarkWidgetFactory : IWidgetFactory
    {
        private readonly Color _widgetColor;
        private readonly Color _textColor;

        public DarkWidgetFactory()
        {
            _widgetColor = Color.Gray;
            _textColor = Color.White;
        }

        public Button CreateButton(Size size, Point position)
        {
            var button = new Button()
            {
                BackColor = _widgetColor,
                ForeColor = _textColor,
                Size = size,
                Location = position
            };

            return button;
        }

        public Label CreateLabel(Size size, Point position)
        {
            var label = new Label()
            {
                BackColor = _widgetColor,
                ForeColor = _textColor,
                Size = size,
                Location = position
            };

            return label;
        }

        public void SetTheme(Control widget)
        {
            widget.BackColor = _widgetColor;
            widget.ForeColor = _textColor;
        }
    }
}
