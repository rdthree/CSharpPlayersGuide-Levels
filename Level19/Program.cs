// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// rectangle class with getter and setter for width/height
// methods for area

class Rectangle
{
    private double _width;
    private double _height;
    private double _area;
    
    Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
        _area = UpdateArea(width, height);
    }

    public double GetWidth() => _width;
    public double GetHeight() => _height;
    public double GetArea() => _area;

    public void SetWidth(double widthNew)
    {
        _width = widthNew;
        UpdateArea(widthNew, _height);
    }

    public void SetHeight(double heightNew)
    {
        _height = heightNew;
        _area = _height * heightNew;
        UpdateArea(_width, heightNew);
    }

    private double UpdateArea(double width, double height) => width * height;
}