using System.Windows;

namespace Figure.Providers.FigureProviders
{
    public class UIFigureProviderResult
    {
        public UIFigureProviderResult(bool success, bool hasParsedProblems, ICollection<UIElement> figures)
        {
            Success = success;
            HasParsedProblems = hasParsedProblems;
            Figures = figures ?? new List<UIElement>();
        }

        public UIFigureProviderResult(bool success)
        {
            Success = success;
            HasParsedProblems = true;
            Figures = new List<UIElement>();
        }

        public bool Success { get; init; }

        public bool HasParsedProblems { get; init; }

        public ICollection<UIElement> Figures { get; init; }
    }
}
