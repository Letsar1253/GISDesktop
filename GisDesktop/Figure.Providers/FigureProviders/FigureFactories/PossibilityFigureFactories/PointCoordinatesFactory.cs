using Figure.Data.Models;

namespace Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories
{
    public class PointCoordinatesFactory : IPossibilityFigureFactory<int[], Point>
    {
        public bool CanCreate(int[] coordinates) => coordinates.Length == 2;

        public Point Create(int[] coordinates) 
        {
            if (!CanCreate(coordinates))
                throw new Exception("Невозможно создать точку");

            return new Point (x: coordinates[0], y: coordinates[1]);
        }
    }
}
