using Figure.Data.Models;

namespace Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories
{
    public class LineCoordinatesFactory : IPossibilityFigureFactory<int[], Line>
    {
        public bool CanCreate(int[] coordinates) => coordinates.Length == 4;

        public Line Create(int[] coordinates)
        {
            var firstPoint = new Point(x: coordinates[0], y: coordinates[1]);
            var secondPoint = new Point (x: coordinates[2], y: coordinates[3]);

            return new Line(firstPoint, secondPoint);
        }
    }
}
