using Figure.Providers.FigureProviders;

namespace GisDesktop.FigureProviders
{
    public interface IUIFigureFileProvider
    {
        Task<UIFigureProviderResult> GetFiguresAsync(string path);
    }
}
