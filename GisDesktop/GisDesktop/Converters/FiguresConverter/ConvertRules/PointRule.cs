using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = Figure.Data.Models.Point;

namespace GisDesktop.Converters.FiguresConverter.ConvertRules
{
    internal class PointRule : IFigureRule<Point, Ellipse>
    {
        private const int _pointSize = 3;
        private readonly Color _color = Colors.Green;

        public Ellipse Convert(Point figure)
        {
            var ellipse = new Ellipse();
            ellipse.Stroke = new SolidColorBrush(_color);
            ellipse.StrokeThickness = 3;
            ellipse.Height = _pointSize;
            ellipse.Width = _pointSize;
            ellipse.Fill = new SolidColorBrush(_color);
            ellipse.Margin = new Thickness(100, 200, 0, 0);

            return ellipse;
        }
    }
}
