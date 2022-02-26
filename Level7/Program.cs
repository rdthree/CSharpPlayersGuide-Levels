// See https://aka.ms/new-console-template for more information


CalcTriArea();

/*
 * take input of triangle base and triangle height
 * return the area
 */
void CalcTriArea()
{
    double triBase, triHeight, triArea;

// welcome intro
    Console.WriteLine("input the base and height of a triangle.  this program will return the area");

// get input
    Console.Write("triangle base: ");
//handleInputRef(ref triBase);
//triBase = handleInput(triBase);
    triBase = InputToDouble();

    Console.Write("triangle height: ");
//handleInputRef(ref triHeight);
//triHeight = handleInput(triHeight);
    triHeight = InputToDouble();

// return result
    Console.WriteLine($"{triBase} x {triHeight} = Area: {triBase * triHeight}");
}

// function for returning result
// validate input, error handling
// this version uses ref to mutate the var directly
void HandleInputRef(ref double input)
{
    while (!double.TryParse(Console.ReadLine(), out input))
        Console.Write("please try again: ");
}

// this version just returns a double
double InputToDouble()
{
    double newInput;
    while (!double.TryParse(Console.ReadLine(), out newInput))
        Console.Write("please try again: ");
    return newInput;
}