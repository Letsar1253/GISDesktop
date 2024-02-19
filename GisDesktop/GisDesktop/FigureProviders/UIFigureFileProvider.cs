using Figure.Providers.FigureProviders;
using GisDesktop.Converters.FiguresConverter;
using System.Windows;

namespace GisDesktop.FigureProviders
{
    internal class UIFigureFileProvider : IUIFigureFileProvider
    {
        private readonly IFigureFileProvider _figureFileProvider;
        private readonly IFiguresConverter _converter;

        public UIFigureFileProvider(IFigureFileProvider figureFileProvider, IFiguresConverter converter)
        {  
            _figureFileProvider = figureFileProvider;
            _converter = converter;
        }

        public async Task<UIFigureProviderResult> GetFiguresAsync(string path)
        {
            var result = await _figureFileProvider.GetFiguresAsync(path);

            if (!result.Success)
                return new UIFigureProviderResult(result.Success);

            var uiElements = new List<UIElement>();
            foreach (var figure in result.Figures) 
            {
                var uiElement = _converter.Convert(figure);
                uiElements.Add(uiElement);
            }

            var uiResult = new UIFigureProviderResult(result.Success, result.HasParsedProblems, uiElements);
            return uiResult;
        }
    }
}
