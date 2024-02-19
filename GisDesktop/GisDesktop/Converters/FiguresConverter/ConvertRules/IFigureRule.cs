using Figure.Data.Models;
using System.Windows;

namespace GisDesktop.Converters.FiguresConverter.ConvertRules
{
    internal interface IFigureRule<in Tin, out Tout>
        where Tin : IFigure
        where Tout : UIElement
    {
        Tout Convert(Tin figure);
    }
}
