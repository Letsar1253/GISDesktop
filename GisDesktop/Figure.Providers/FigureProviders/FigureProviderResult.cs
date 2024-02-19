using Figure.Data.Models;

namespace Figure.Providers.FigureProviders
{
    public class FigureProviderResult
    {
        public FigureProviderResult(bool success, bool hasParsedProblems, ICollection<IFigure> figures)
        {
            Success = success;
            HasParsedProblems = hasParsedProblems;
            Figures = figures ?? new List<IFigure>();
        }

        public FigureProviderResult(bool success)
        {
            Success = success;
            HasParsedProblems = true;
            Figures = new List<IFigure>();
        }

        public bool Success { get; init; }

        public bool HasParsedProblems { get; init; }

        public ICollection<IFigure> Figures { get; init; }
    }
}
