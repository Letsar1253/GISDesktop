using Figure.Providers.FigureProviders.Factories;
using GisDesktop.Converters.FiguresConverter.Factories;

namespace GisDesktop.FigureProviders.Factories
{
    internal class UIFigureFileProviderFactory : IUIFigureFileProviderFactory
    {
        private readonly IFigureFileProviderFactory _figureFileProviderFactory;
        private readonly IFiguresConverterFactory _figuresConverterFactory;

        public UIFigureFileProviderFactory(IFigureFileProviderFactory figureFileProviderFactory, IFiguresConverterFactory figuresConverterFactory)
        {
            _figureFileProviderFactory = figureFileProviderFactory;
            _figuresConverterFactory = figuresConverterFactory;
        }

        public IUIFigureFileProvider Create()
        {
            var figureFileProvider = _figureFileProviderFactory.Create();
            var converter = _figuresConverterFactory.Create();

            var uiFigureFileProvider = new UIFigureFileProvider(figureFileProvider, converter);

            return uiFigureFileProvider;
        }
    }
}
