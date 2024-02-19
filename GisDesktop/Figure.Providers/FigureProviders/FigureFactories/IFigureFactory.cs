using Figure.Data.Models;

namespace Figure.Providers.FigureProviders.FigureFactories
{
    public interface IFigureFactory<in Tin, out Tout>
        where Tout : IFigure
    {
        Tout Create(Tin data);
    }
}
