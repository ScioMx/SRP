namespace Shapes.Solution
{
    /// <summary>
    /// Class calculates the rectangle's area.
    /// </summary>
    public class RectangleShape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Area()
        {
            return Width * Height;
        }
    }
}
