using GisDesktop.Converters.FiguresConverter.ConvertRules;

namespace GisDesktop.Converters.FiguresConverter.Factories
{
    internal class FiguresConverterFactory : IFiguresConverterFactory
    {
        public IFiguresConverter Create()
        {
            var pointRule = new PointRule();
            var lineRule = new LineRule();
            var polygonRule = new PolygonRule();

            var converter = new FiguresConverter(pointRule, lineRule, polygonRule);

            return converter;
        }
    }
}
