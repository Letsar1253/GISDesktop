using System.Windows.Media;
using System.Windows;
using PolygonFigure = Figure.Data.Models.Polygon;
using UIPolygon = System.Windows.Shapes.Polygon;

namespace GisDesktop.Converters.FiguresConverter.ConvertRules
{
    internal class PolygonRule : IFigureRule<PolygonFigure, UIPolygon>
    {
        private readonly Color _color = Colors.Red;

        public UIPolygon Convert(PolygonFigure polygon) 
        {
            var points = new PointCollection();   
            foreach (var vertex in polygon.Vertices)
            {
                var point = new Point(vertex.X, vertex.Y);
                points.Add(point);
            }

            var uiPolygon = new UIPolygon();
            uiPolygon.Stroke = new SolidColorBrush(_color);
            uiPolygon.Fill = new SolidColorBrush(_color);
            uiPolygon.StrokeThickness = 1;
            uiPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            uiPolygon.VerticalAlignment = VerticalAlignment.Center;
            uiPolygon.Points = points;

            return uiPolygon;
        }
    }
}
