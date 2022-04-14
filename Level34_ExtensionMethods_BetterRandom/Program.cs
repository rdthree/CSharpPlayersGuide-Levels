var words = new List<string>()
{
    "up",
    "down",
    "left",
    "right"
};

double nextTen;

//var loop = new Random().NextDouble().NextMaxDouble(9);
var loop = new Random();
loop.NextMaxDouble(5.0f);
var poop = new Random().NextMaxDouble(9.0);

for (var i = 0; i < 10; i++)
{
    nextTen = new Random().NextDouble() * 10.0;
    var nextWord = new Random().Next(0, 4);
    
    Console.WriteLine($"next double: {nextTen}");
    Console.WriteLine($"next word {words[nextWord]}");
}

for (var i = 0; i < 10; i++)
{
    nextTen = new Random().NextDouble() * 10.0;
    bool coinFlip;

    if (nextTen > 5)
    {
        var fairOdds = new Random().Next(0, 1);
        coinFlip = fairOdds == 0;
        Console.WriteLine($"fair coin toss, (true is heads, false is tails) {coinFlip}");
    }
    else if (nextTen < 5)
    {
        var unfairOdds = new Random().NextDouble() * 1.5;
        coinFlip = unfairOdds > 0.5;
        Console.WriteLine($"unfair coin toss, (true is heads, false is tails) {coinFlip}");
    }
}

public static class RandomExtensions
{
    public static double NextMaxDouble(this Random rand, double input)
    {
        return rand.NextDouble() * input;
    }
}