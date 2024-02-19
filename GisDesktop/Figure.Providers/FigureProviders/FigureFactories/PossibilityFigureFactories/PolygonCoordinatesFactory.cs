using Figure.Data.Models;

namespace Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories
{
    public class PolygonCoordinatesFactory : IPossibilityFigureFactory<int[], Polygon>
    {
        public bool CanCreate(int[] coordinates) => coordinates.Length >= 6;

        public Polygon Create(int[] coordinates)
        {
            var points = new List<Point>();

            for (int i = 0; i < coordinates.Length; i = i + 2)
            {
                var point = new Point (x: coordinates[i], y: coordinates[i + 1]);
                points.Add(point);
            }

            return new Polygon(points);
        }
    }
}
