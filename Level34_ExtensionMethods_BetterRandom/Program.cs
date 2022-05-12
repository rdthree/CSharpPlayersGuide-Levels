// ReSharper disable UnusedVariable
// ReSharper disable RedundantExplicitArrayCreation
// ReSharper disable NotAccessedVariable
// ReSharper disable RedundantAssignment
var words = new List<string>()
{
    "up",
    "down",
    "left",
    "right"
};

double nextTen;

var loop = new Random().NextMaxDouble(9.0);
var stringers = new string[] {"yo", "so", "flow", "crow", "man", "barn"};



for (var i = 0; i < 10; i++)
{
    nextTen = new Random().NextDouble() * 10.0;
    var nextWord = new Random().Next(0, 4);
    
    //Console.WriteLine($"next double: {nextTen}");
    //Console.WriteLine($"next word {words[nextWord]}");
    
    var stingO = new Random().NextString(stringers);
    //Console.WriteLine(stingO);
    
}

for (var i = 0; i < 10; i++)
{
    nextTen = new Random().NextDouble() * 10.0;
    bool coinFlip;

    if (nextTen > 5)
    {
        var fairOdds = new Random().Next(0, 1);
        coinFlip = fairOdds == 0;
        //Console.WriteLine($"fair coin toss, (true is heads, false is tails) {coinFlip}");
    }
    else if (nextTen < 5)
    {
        var unfairOdds = new Random().NextDouble() * 1.5;
        coinFlip = unfairOdds > 0.5;
        //Console.WriteLine($"unfair coin toss, (true is heads, false is tails) {coinFlip}");
    }
}

public static class RandomExtensions
{
    public static double NextMaxDouble(this Random rand, double input) => rand.NextDouble() * input;
    public static string NextString(this Random rand, params string[] strings) => strings[rand.Next(strings.Length)];
    public static bool CoinFlip(this Random rand, double odds = 0.5) => rand.NextDouble() > odds;
}