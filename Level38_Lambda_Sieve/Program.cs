// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// program that takes numbers and judges them as 'good' or 'bad'

Console.WriteLine("1: evens | 2: positives | 3: multiple of ten | (default is 1)");
int.TryParse(Console.ReadLine(), out var choice);
var sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n >= 0),
    3 => new Sieve(n => n % 10 == 0),
    _ => new Sieve(n => n % 2 == 0)
};

while (true)
{
    Console.Write("enter number: ");
    int.TryParse(Console.ReadLine(), out var input);

    string goodOrBad = sieve.IsGood(input) ? "good" : "bad";
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{goodOrBad}");
    Console.ResetColor();
}

internal class Sieve
{
    private readonly Func<int, bool> _filter;
    internal Sieve(Func<int, bool> operation) => _filter = operation;
    internal bool IsGood(int number) => _filter(number);
} 