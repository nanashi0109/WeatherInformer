using System.Drawing;
using System.Windows.Forms;

namespace WeatherInformer.WidgetFactory
{
    public class LightWidgetFactory : IWidgetFactory
    {
        private readonly Color _color;
        private readonly Color _textColor;

        public LightWidgetFactory() 
        {
            _color = Color.White;
            _textColor = Color.Black;
        }

        public Button CreateButton(Size size, Point position)
        {
            var button = new Button() 
            {
                BackColor = _color,
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
                BackColor = _color,
                ForeColor = _textColor,
                Size = size,
                Location = position
            };
            
            return label;
        }

        public void SetTheme(Control widget)
        {
            widget.BackColor = _color;
            widget.ForeColor = _textColor;
        }
    }
}
