// See https://aka.ms/new-console-template for more information

var cacaRectangle = Rectangle.Square(3);
Console.WriteLine(cacaRectangle);
internal class Rectangle
{
    private double Width { get; }
    private double Height { get; }
    internal double Area => Width * Height;

    private Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    internal static Rectangle Square(double sideLength) => new Rectangle(sideLength, sideLength);
}