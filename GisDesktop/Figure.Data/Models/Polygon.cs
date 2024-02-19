namespace Figure.Data.Models
{
    public record Polygon : IFigure
    {
        public Polygon(ICollection<Point> vertices)
        {
            Vertices = vertices;
        }

        public ICollection<Point> Vertices { get; init; }
    }
}
