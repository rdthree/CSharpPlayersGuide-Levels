// See https://aka.ms/new-console-template for more information
/*
 * a person approaches and the dialog that follows makes up the game
 */
Console.WriteLine("what kind of thing are you talking about");
// input the thing in question
string a = Console.ReadLine();
Console.WriteLine("desribe it");
// input a description
string b = Console.ReadLine();
// built-in descriptions
string c = "of doom";
string d = "3000";

// final output
Console.WriteLine($"the {b} {a} of {c} {d}");