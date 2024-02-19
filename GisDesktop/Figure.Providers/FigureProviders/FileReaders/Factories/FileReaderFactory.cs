using Figure.Providers.FigureProviders.FileReaders.Factory;

namespace Figure.Providers.FigureProviders.FileReaders.Factories
{
    public class FileReaderFactory : IFileReaderFactory
    {
        public IFileReader Create(string absoluteFilePath) => new FileReader(absoluteFilePath);

    }
}
