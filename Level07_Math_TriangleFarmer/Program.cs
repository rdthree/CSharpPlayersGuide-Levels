// See https://aka.ms/new-console-template for more information

/*
 * this was helpful:
 * https://gist.github.com/ZacharyPatten/798ed612d692a560bdd529367b6a7dbd#example-6-optional-code-style-changes-over-example-5
 */

using static System.Console;

#pragma warning disable CA1416
Beep(440, 100);
#pragma warning restore CA1416
#pragma warning disable CA1416
Beep(840, 50);
#pragma warning restore CA1416
#pragma warning disable CA1416
Beep(1240, 100);
#pragma warning restore CA1416

Title = "Level 7";
BackgroundColor = ConsoleColor.DarkBlue;
ForegroundColor = ConsoleColor.White;

CalcTriArea();
EggDivider();
PassTheDuchy();

ReadKey();

/*
 * users enter how many provinces, duchies, estates they have.  the program returns the total value
 * each estate is   1
 * each duchy is    3
 * each province is 6
 */

void PassTheDuchy()
{
    WriteLine("What is your new worth?");
    Write("Total Estates: ");
    var estates = InputToUint();
    Write("Total Duchies: ");
    var duchies = InputToUint() * 3;
    Write("Total Provinces: ");
    var provinces = InputToUint() * 6;
    WriteLine($"You own:\n" +
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
    Write($"Please input quantity of eggs (max {uint.MaxValue}): ");
    var eggs = InputToUint();
    var eggsDivided = eggs / 4;
    var eggsRemainder = eggs % 4;
    WriteLine($"Each sister gets {eggsDivided, 30}.\nThe duckbear gets {eggsRemainder, 30}.");


    WriteLine("\nFYI");
    WriteLine("These egg quantities result in the duckbear getting more eggs than each sister:");
    for (var i = 0; i < 100; i++)
        if (i / 4 < i % 4) Write($"\n\t\t(({i})) ");
    WriteLine("\n");
}

/*
 * take input of triangle base and triangle height
 * return the area
 */
void CalcTriArea()
{
#pragma warning disable CS0168
    double triArea;
#pragma warning restore CS0168

    // welcome intro
    WriteLine("input the base and height of a triangle.  this program will return the area");

    // get input
    Write("triangle base: ");
    //handleInputRef(ref triBase);
    //triBase = handleInput(triBase);
    var triBase = InputToDouble();

    Write("triangle height: ");
    //handleInputRef(ref triHeight);
    //triHeight = handleInput(triHeight);
    var triHeight = InputToDouble();

    // return result
    WriteLine($"{triBase} x {triHeight} = Area: {triBase * triHeight}");
}

// function for returning result
// validate input, error handling
// this version uses ref to mutate the var directly
#pragma warning disable CS8321
void HandleInputRef(ref double input)
#pragma warning restore CS8321
{
    if (input <= 0) throw new ArgumentOutOfRangeException(nameof(input));
    while (!double.TryParse(ReadLine(), out input))
        Write("please try again: ");
}

// this version just returns a double
double InputToDouble()
{
    double newInput;
    while (!double.TryParse(ReadLine(), out newInput))
        Write("please try again: ");
    return newInput;
}

uint InputToUint()
{
    uint newInput;
    while (!uint.TryParse(ReadLine(), out newInput))
        Write("please try again: ");
    return newInput;
}