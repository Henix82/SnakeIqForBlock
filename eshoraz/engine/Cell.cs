using System.Drawing;

namespace eshoraz.engine
{
    public enum TypeCell
    {
        Void, Obstacle, Feed, Snake
    }
    internal class Cell
    {
        public Point Point { get; set; }
        public TypeCell Type { get; set; }

    }
}
