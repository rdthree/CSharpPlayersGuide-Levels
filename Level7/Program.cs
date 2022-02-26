// See https://aka.ms/new-console-template for more information

/*
 * this was helpful:
 * https://gist.github.com/ZacharyPatten/798ed612d692a560bdd529367b6a7dbd#example-6-optional-code-style-changes-over-example-5
 */

CalcTriArea();
EggDivider();
PassTheDuchy();

Console.ReadKey();

/*
 * users enter how many provinces, duchies, estates they have.  the program returns the total value
 * each estate is   1
 * each duchy is    3
 * each province is 6
 */

void PassTheDuchy()
{
    Console.WriteLine("What is your new worth?");
    Console.Write("Total Estates: ");
    var estates = InputToUint();
    Console.Write("Total Duchies: ");
    var duchies = InputToUint() * 3;
    Console.Write("Total Provinces: ");
    var provinces = InputToUint() * 6;
    Console.WriteLine($"You own:\n" +
                      $"{duchies} \tin duchies\n" +
                      $"{estates} \tin estates\n" +
                      $"{provinces} \tin provinces\n" +
                      $"-----------------------\n" +
                      $"{duchies+estates+provinces} \ttotal net worth");
}

/*
 * take input of daily egs, divide input equally among 4 sisters
 * the remainder goes to the duckbear
 */
void EggDivider()
{
    Console.Write($"Please input quantity of eggs (max {uint.MaxValue}): ");
    var eggs = InputToUint();
    var eggsDivided = eggs / 4;
    var eggsRemainder = eggs % 4;
    Console.WriteLine($"Each sister gets {eggsDivided}. The duckbear gets {eggsRemainder}.");


    Console.WriteLine("\nFYI");
    Console.WriteLine("These egg quantities result in the duckbear getting more eggs than each sister:");
    for (var i = 0; i < 100; i++)
        if (i / 4 < i % 4) Console.Write($"(({i})) ");
}

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

uint InputToUint()
{
    uint newInput;
    while (!uint.TryParse(Console.ReadLine(), out newInput))
        Console.Write("please try again: ");
    return newInput;
}