namespace Figure.Providers.FigureProviders.Parsers
{
    public interface ILineParser<T>
    {
        bool TryParse(string line, out T data);
    }
}
