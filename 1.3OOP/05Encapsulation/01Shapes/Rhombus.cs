namespace _01Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double height) : base(width, height)
        {

        }

        public override double CalculateArea()
        {
            return Width*Height;
        }
        public override double CalculatePerimeter()
        {
            return Width*4;
        }
    }
}