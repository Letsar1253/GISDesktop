namespace Figure.Data.Models
{
    public record Line : IFigure
    {
        public Line(Point firstPoint, Point secondPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        public Point FirstPoint { get; init; }

        public Point SecondPoint { get; init; }
    }
}
