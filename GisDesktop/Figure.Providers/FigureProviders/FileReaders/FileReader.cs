using System.Text;

namespace Figure.Providers.FigureProviders.FileReaders
{
    internal class FileReader : IFileReader
    {
        private FileStream? _fileStream;
        private StreamReader? _streamReader;
        private string? _nextLine;
        private bool _disposed;

        public FileReader(string absoluteFilePath)
        {
            _fileStream = File.OpenRead(absoluteFilePath);
            _streamReader = new StreamReader(_fileStream, Encoding.UTF8);
        }

        ~FileReader() => Dispose(false);

        public async ValueTask<bool> TryMoveNextLineAsync()
        {
            if (_streamReader is null)
                throw new Exception("StreamReader не задан");

            var line = await _streamReader.ReadLineAsync().ConfigureAwait(false);

            if (line is null)
                return false;

            _nextLine = line;
            return true;
        }

        public string GetNextLine()
        {
            if (_nextLine is null)
                throw new Exception("Следующая строка не задана");

            return _nextLine;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _streamReader?.Dispose();
                    _streamReader = null;

                    _fileStream?.Dispose();
                    _fileStream = null;
                }

                _nextLine = null;

                _disposed = true;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            _streamReader?.Dispose();
            _streamReader = null;

            if (_fileStream is not null)
            {
                await _fileStream.DisposeAsync().ConfigureAwait(false);
                _fileStream = null;
            }
        }
    }
}
