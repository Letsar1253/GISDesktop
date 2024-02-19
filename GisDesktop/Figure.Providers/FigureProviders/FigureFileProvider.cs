using Figure.Data.Models;
using Figure.Providers.FigureProviders.FigureFactories;
using Figure.Providers.FigureProviders.FileReaders.Factory;
using Figure.Providers.FigureProviders.Parsers;

namespace Figure.Providers.FigureProviders
{
    public class FigureFileProvider : IFigureFileProvider
    {
        private readonly ILineParser<int[]> _parser;
        private readonly IFigureFactory<int[], IFigure> _figureFactory;
        private readonly IFileReaderFactory _fileReaderFactory;

        public FigureFileProvider(ILineParser<int[]> parser, IFigureFactory<int[], IFigure> figureFactory, IFileReaderFactory fileReaderFactory)
        {
            _parser = parser;
            _figureFactory = figureFactory;
            _fileReaderFactory = fileReaderFactory;
        }

        public async Task<FigureProviderResult> GetFiguresAsync(string absolutePath)
        {
            try
            {
                bool hasParsedProblems = false;
                var figures = new List<IFigure>();

                await using (var fileReader = _fileReaderFactory.Create(absolutePath))
                {
                    while (await fileReader.TryMoveNextLineAsync().ConfigureAwait(false))
                    {
                        var line = fileReader.GetNextLine();

                        if(string.IsNullOrEmpty(line))
                            continue;

                        if (!_parser.TryParse(line, out var coordinates))
                        {
                            hasParsedProblems = true;
                            continue;
                        }

                        var figure = _figureFactory.Create(coordinates);
                        figures.Add(figure);
                    }
                }

                var success = true;
                return new FigureProviderResult(success, hasParsedProblems, figures);
            }
            catch (Exception)
            {
                var notSuccess = false;
                return new FigureProviderResult(notSuccess);
            }
        }
    }
}
