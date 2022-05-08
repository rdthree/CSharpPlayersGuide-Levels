// See https://aka.ms/new-console-template for more information

using Level36_Delegates_TheSieve;

// test out delegates and how they work

int AddOne(int number) => number + 1;
/*
int SubtractOne(int number) => number - 1;
*/
/*
int Double(int number) => number * 2;
*/

var poop = ChangeArrayElements(new[] { 1, 2, 3, 4, 5, 6 }, AddOne);
foreach (var i in poop) Console.WriteLine(i);

int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
{
    var result = new int[numbers.Length];

    for (int index = 0; index < result.Length; index++)
    {
        result[index] = operation.Invoke(numbers[index]);
        //result[index] = operation(numbers[index]);
    }

    return result;
}

// program takes numbers and judges them as 'good' or 'bad'

bool IsEven(int num) => num % 2 == 0;
bool IsPositive(int num) => num >= 0;
bool IsTens(int num) => num % 10 == 0;

Console.WriteLine("1: evens | 2: positives | 3: multiple of tens");
int.TryParse(Console.ReadLine(), out var choice);
var sieveTest = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsTens),
    _ => throw new ArgumentOutOfRangeException()
};

while (true)
{
    Console.Write("enter number: ");
    int.TryParse(Console.ReadLine(), out var input);

    string goodOrEvil = sieveTest.IsGood(input) ? "good" : "evil";
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"input is: {goodOrEvil}");
}