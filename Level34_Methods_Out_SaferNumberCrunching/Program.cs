// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var run = false;
while (!run)
{
    Console.Write("input an integer:");
    var input = Console.ReadLine();
    run = int.TryParse(input, out int checkedInput);
    if (!run)
    {
        Console.WriteLine("please try again");
        continue;
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"you input: {checkedInput}");
    Console.ResetColor();
}