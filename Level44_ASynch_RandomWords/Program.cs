// See https://aka.ms/new-console-template for more information

//RandomlyRecreate("fly");
var randoWord1 = RandomlyRecreate("fly");
var randoWord2 = RandomlyRecreate("flys");
var randoWord3 = RandomlyRecreate("flown");
await randoWord1;
await randoWord2;
await randoWord3;
var result1 = randoWord1.Result;
var result2 = randoWord2.Result;
var result3 = randoWord3.Result;

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);

while (true)
{
    Console.WriteLine();
    Console.Write("input word, max 4 characters: ");
    var word = Console.ReadLine();
    // ReSharper disable once UnusedVariable
#pragma warning disable CS8604
    var inputWord = RandomlyRecreate(word);
#pragma warning restore CS8604
}


Task<int> RandomlyRecreate(string word)
{
    var attempts = 0;
    var done = false;
    var letters = new char[word.Length];
    var random = new Random();
    var start = DateTime.Now.Second;

    return Task.Run(() =>
    {
        while (!done)
        {
            for (int i = 0; i < word.Length; i++)
                letters[i] = (char) ('a' + random.Next(26));

            var newWord = new string(letters);
            //Console.WriteLine($"{word} | {newWord}");
            attempts++;
            if (newWord == word)
            {
                var time = DateTime.Now.Second - start;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"DONE: found {word} in {attempts} tries and {time} seconds");
                Console.WriteLine();
                Console.ResetColor();
                done = true;
            }

        }

        return attempts;
    });
}