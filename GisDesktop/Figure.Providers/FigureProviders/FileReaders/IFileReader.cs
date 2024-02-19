namespace Figure.Providers.FigureProviders.FileReaders
{
    public interface IFileReader : IDisposable, IAsyncDisposable
    {
        ValueTask<bool> TryMoveNextLineAsync();

        string GetNextLine();
    }
}
