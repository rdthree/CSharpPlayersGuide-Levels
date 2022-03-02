// See https://aka.ms/new-console-template for more information

using MonchoUtils;

var arrayFive = new uint[5];
var arrayFiveDeuce = new uint[5];

for (var i = 0; i < arrayFive.Length; i++)
{
    Console.Write($"input item {i}: ");
    arrayFive[i] = MoUtils.InputToUint();
}

Console.Write($"copying items from arrayFive into arrayFiveDeuce:");
for (var i = 0; i < arrayFive.Length; i++)
{
    arrayFiveDeuce[i] = arrayFive[i];
    Console.Write($" {arrayFiveDeuce[i]} ");
}

Console.WriteLine("");
Console.WriteLine("items in arrayFive:");
foreach (var item in arrayFive)
    Console.Write($" {item} ");
Console.WriteLine("");

Console.WriteLine("items in arrayFiveDeuce:");
foreach (var item in arrayFiveDeuce)
    Console.Write($" {item} ");