using System.Drawing;
using System.Windows.Forms;

namespace WeatherInformer.WidgetFactory
{
    public interface IWidgetFactory
    {
        Button CreateButton(Size size, Point position);

        Label CreateLabel(Size size, Point position);

        void SetTheme(Control widget);
    }

}
