using Figure.Providers.FigureProviders.Parsers.Validators;

namespace Figure.Providers.FigureProviders.Parsers
{
    public class LineCoordinatesParser : ILineParser<int[]>
    {
        private readonly IStringsValidator _validator;

        public LineCoordinatesParser(IStringsValidator validator)
        {
            _validator = validator;
        }

        public bool TryParse(string line, out int[] coordinates)
        {
            var strings = line.Split(' ');

            coordinates = null;
            if (!_validator.Validate(strings))
                return false;

            coordinates = strings.Select(int.Parse).ToArray();
            return true;
        }
    }
}
