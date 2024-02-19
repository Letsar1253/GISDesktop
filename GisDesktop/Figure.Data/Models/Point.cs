namespace Figure.Data.Models
{
    public record Point : IFigure
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }

        public int Y { get; init; }
    }
}
