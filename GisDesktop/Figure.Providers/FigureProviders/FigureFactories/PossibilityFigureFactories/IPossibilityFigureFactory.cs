using Figure.Data.Models;

namespace Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories
{
    public interface IPossibilityFigureFactory<in Tin, out Tout> : IFigureFactory<Tin, Tout>
        where Tout : IFigure
    {
        bool CanCreate(Tin data);
    }
}
