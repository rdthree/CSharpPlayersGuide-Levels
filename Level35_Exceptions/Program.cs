// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// 2 players
// pick random numbers
// if random number previously chosen then flag it
// if random number was secretly chosen by the game - game over, throw an exception
// use try/catch block to handle exception and display results

var rand = new Random();

var boom = rand.Next(10);
var guessed = new List<int>();
Console.WriteLine("guess a number 1 to 10");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("guess");
    int.TryParse(Console.ReadLine(), out int guess);
    guessed.Add(guess);
}