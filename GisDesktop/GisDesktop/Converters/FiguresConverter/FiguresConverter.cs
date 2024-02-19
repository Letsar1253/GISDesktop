using Figure.Data.Models;
using GisDesktop.Converters.FiguresConverter.ConvertRules;
using System.Windows;
using PolygonFigure = Figure.Data.Models.Polygon;
using UIPolygon = System.Windows.Shapes.Polygon;
using Point = Figure.Data.Models.Point;
using LineFigure = Figure.Data.Models.Line;
using UILine = System.Windows.Shapes.Line;
using System.Windows.Shapes;

namespace GisDesktop.Converters.FiguresConverter
{
    internal class FiguresConverter : IFiguresConverter
    {
        private readonly IFigureRule<Point, Ellipse> _pointRule;
        private readonly IFigureRule<LineFigure, UILine> _lineRule;
        private readonly IFigureRule<PolygonFigure, UIPolygon> _polygonRule;

        public FiguresConverter(IFigureRule<Point, Ellipse> pointRule, IFigureRule<LineFigure, UILine> lineRule, IFigureRule<PolygonFigure, UIPolygon> polygonRule) 
        {
            _pointRule = pointRule;
            _lineRule = lineRule;
            _polygonRule = polygonRule;
        }

        public UIElement Convert<T>(T figure)
            where T : IFigure
        {
            var figureType = typeof(T);

            if (figure is Point point)
                return _pointRule.Convert(point);

            if (figure is LineFigure line)
                return _lineRule.Convert(line);

            if (figure is PolygonFigure polygon)
                return _polygonRule.Convert(polygon);

            throw new Exception("Не удалось найти правило для конвертации");
        }
    }
}
