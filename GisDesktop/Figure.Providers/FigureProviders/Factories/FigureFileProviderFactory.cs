using Figure.Providers.FigureProviders.FigureFactories.PossibilityFigureFactories;
using Figure.Providers.FigureProviders.FigureFactories;
using Figure.Providers.FigureProviders.FileReaders.Factories;
using Figure.Providers.FigureProviders.Parsers.Validators;
using Figure.Providers.FigureProviders.Parsers;
using Figure.Data.Models;
using Figure.Providers.FigureProviders.FileReaders.Factory;

namespace Figure.Providers.FigureProviders.Factories
{
    public class FigureFileProviderFactory : IFigureFileProviderFactory
    {
        private readonly ILineParser<int[]> _lineCoordinatesParser;
        private readonly IFigureFactory<int[], IFigure> _figureFactory;
        private readonly IFileReaderFactory _fileReaderFactory;

        public FigureFileProviderFactory()
        {
            var stringsCoordinatesValidator = new StringsCoordinatesValidator();
            _lineCoordinatesParser = new LineCoordinatesParser(stringsCoordinatesValidator);
            _figureFactory = new FiguresFactory(new LineCoordinatesFactory(), new PointCoordinatesFactory(), new PolygonCoordinatesFactory());
            _fileReaderFactory = new FileReaderFactory();
        }

        public IFigureFileProvider Create() => new FigureFileProvider(_lineCoordinatesParser, _figureFactory, _fileReaderFactory);
    }
}
