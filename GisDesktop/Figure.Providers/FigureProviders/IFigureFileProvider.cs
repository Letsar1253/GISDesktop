using Figure.Data.Models;

namespace Figure.Providers.FigureProviders
{
    public interface IFigureFileProvider
    {
        Task<FigureProviderResult> GetFiguresAsync(string absolutePath);
    }
}