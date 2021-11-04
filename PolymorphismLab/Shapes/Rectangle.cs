namespace Shapes
{
    public class Rectangle : Shape
    {
        private readonly double height;
        private readonly double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * width + 2 * height;
        }
        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
