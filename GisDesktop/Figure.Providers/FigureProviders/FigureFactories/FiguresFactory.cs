using Figure.Data.Models;
using Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories;

namespace Figure.Providers.FigureProviders.FigureFactories
{
    public class FiguresFactory : IFigureFactory<int[], IFigure>
    {
        private readonly ICollection<IPossibilityFigureFactory<int[], IFigure>> _possibilityFactories;

        public FiguresFactory(params IPossibilityFigureFactory<int[], IFigure>[] possibilityFigures) 
        {
            _possibilityFactories = possibilityFigures;
        }

        public IFigure Create(int[] coordinates)
        {
            foreach (var possibilityFactory in _possibilityFactories)
            {
                if(possibilityFactory.CanCreate(coordinates))
                    return possibilityFactory.Create(coordinates);
            }

            throw new Exception("Не удалось создать фигуру по координатам");
        }
    }
}
