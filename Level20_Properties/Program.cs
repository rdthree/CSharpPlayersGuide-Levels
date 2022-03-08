// See https://aka.ms/new-console-template for more information

using MonchoUtils;

var caca = Rectangle.Square(3);
Console.WriteLine(caca);
internal class Rectangle
{
    private double Width { get; } = 0;
    private double Height { get; } = 0;
    internal double Area => Width * Height;

    internal Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    internal static Rectangle Square(double sideLength) => new Rectangle(sideLength, sideLength);
}