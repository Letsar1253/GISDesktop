using Figure.Data.Models;
using System.Windows;

namespace GisDesktop.Converters.FiguresConverter
{
    internal interface IFiguresConverter
    {
        UIElement Convert<T>(T figure)
            where T : IFigure;
    }
}
