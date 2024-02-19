namespace Figure.Providers.FigureProviders.Parsers.Validators
{
    public class StringsCoordinatesValidator : IStringsValidator
    {
        public bool Validate(string[] strings) => IsParity(strings) && IsInt(strings) && strings.Length > 0;

        private bool IsParity(string[] strings) => strings.Length % 2 == 0;

        private bool IsInt(string[] strings) => strings.All(a => int.TryParse(a, out var intValue));
    }
}
