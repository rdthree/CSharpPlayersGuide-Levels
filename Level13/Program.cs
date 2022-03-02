// See https://aka.ms/new-console-template for more information

using MonchoUtils;

Console.WriteLine($"factorial of 5 = {Factorial(5)}");
Factorial(5);
Console.WriteLine("");
Countdown(5);

int Factorial(int number)
{
    Console.Write(number != 1 ? $"{number} x " : $"{number} = \n");
    if (number <= 1) return 1; // end of the line
    number *= Factorial(number - 1); // recursive function
    Console.WriteLine(number);
    return number; // this could have been combined with line above, but more clear this way
}

int Countdown(int number)
{
    Console.Write(number != 1 ? $"{number}, " : $"{number}");
    if (number <= 1) return 1;
    number += Countdown(number - 1);
    return number;
}