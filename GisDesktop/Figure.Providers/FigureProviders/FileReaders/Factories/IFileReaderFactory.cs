namespace Figure.Providers.FigureProviders.FileReaders.Factory
{
    public interface IFileReaderFactory
    {
        IFileReader Create(string absoluteFilePath);
    }
}
