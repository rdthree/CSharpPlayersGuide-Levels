// See https://aka.ms/new-console-template for more information

// ReSharper disable RedundantAssignment
Console.Write("Enter your name: ");
var name = Console.ReadLine();

var score = 0;

Console.Write("input data: ");
var data = Console.ReadLine();
if (data != null)
{
    var dataTrim = string.Concat(data.Where(c => !char.IsWhiteSpace(c)));
    score = dataTrim.Length;
}

var playerScore = new Score(name, data, score);
File.WriteAllText("score.txt", playerScore.ToString());

public record Score(string? Name, string? Data, int Points);