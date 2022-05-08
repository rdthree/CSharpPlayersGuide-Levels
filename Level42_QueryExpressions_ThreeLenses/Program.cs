// See https://aka.ms/new-console-template for more information

var originalNumbers = new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

Console.WriteLine("procedural lens");
IEnumerable<int>? lensOne = LensProcedural(originalNumbers);
if (lensOne != null)
    foreach (var i in lensOne)
        Console.WriteLine(i);

Console.WriteLine("query based lens");
IEnumerable<int> lensTwo = LensKeywordQuery(originalNumbers);
foreach (var i in lensTwo) Console.WriteLine(i);

Console.WriteLine("method based query lens");
IEnumerable<int> lensThree = LensMethodQuery(originalNumbers);
lensThree.ToList().ForEach(Console.WriteLine);

IEnumerable<int>? LensProcedural(int[] numbers)
{
    var newNums = new List<int>();
    foreach (var number in numbers)
        if (number % 2 == 0)
            newNums?.Add(number * 2);
    newNums?.Sort();
    return newNums;
}

IEnumerable<int> LensKeywordQuery(int[] numbers)
{
    IEnumerable<int> newNums = from n in numbers
        where n % 2 == 0
        orderby n
        select n * 2;
    return newNums;
}

IEnumerable<int> LensMethodQuery(int[] numbers)
{
    var newNums = numbers
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2);
    return newNums;
}