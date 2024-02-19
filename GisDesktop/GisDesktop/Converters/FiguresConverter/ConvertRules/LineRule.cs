using System.Windows.Media;
using LineFigure = Figure.Data.Models.Line;
using UILine = System.Windows.Shapes.Line;

namespace GisDesktop.Converters.FiguresConverter.ConvertRules
{
    internal class LineRule : IFigureRule<LineFigure, UILine>
    {
        private readonly Color _color = Colors.Blue;

        public UILine Convert(LineFigure line)
        {
            var uiLine = new UILine();
            uiLine.X1 = line.FirstPoint.X;
            uiLine.Y1 = line.FirstPoint.Y;
            uiLine.X2 = line.SecondPoint.X;
            uiLine.Y2 = line.SecondPoint.Y;
            uiLine.StrokeThickness = 2;
            uiLine.Stroke = new SolidColorBrush(_color); ;

            return uiLine;
        }
    }
}
