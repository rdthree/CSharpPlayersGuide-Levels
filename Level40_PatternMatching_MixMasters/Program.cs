// See https://aka.ms/new-console-template for more information

// ReSharper disable UnusedVariable
var drink = DrinkMix.Water;
while (true)
{
    drink = drink == DrinkMix.Ruined ? DrinkMix.Water : drink;
    Console.WriteLine($"you currently have a {drink} drink");
    Console.Write("please pick an ingredient from 1 to 5: ");
    var input = Console.ReadLine();
    var getIngredient = int.TryParse(input, out var choice);
    var ingredientIndex = choice is <= 1 or >= 5 ? 1 : choice;
    var ingredient = (Ingredient)ingredientIndex;

    drink = (drink, ingredient) switch
    {
        (DrinkMix.Water, Ingredient.Stardust) => DrinkMix.Elixir,
        (DrinkMix.Elixir, Ingredient.SnakeVenom) => DrinkMix.Poison,
        (DrinkMix.Elixir, Ingredient.DogBreath) => DrinkMix.Flying,
        (DrinkMix.Elixir, Ingredient.ShadowGlass) => DrinkMix.Invisibility,
        (DrinkMix.Elixir, Ingredient.GreenGem) => DrinkMix.NightVision,
        (DrinkMix.Invisibility, Ingredient.ShadowGlass) => DrinkMix.CloudyBrew,
        (DrinkMix.Invisibility, Ingredient.GreenGem) => DrinkMix.CloudyBrew,
        (DrinkMix.CloudyBrew, Ingredient.Stardust) => DrinkMix.Wiggler,
        _ => DrinkMix.Ruined
    };

    if (drink == DrinkMix.Ruined) Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"you added some {ingredient} to your {drink} drink");
    Console.WriteLine();
    Console.ResetColor();
}

enum DrinkMix
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightVision,
    CloudyBrew,
    Wiggler,
    Ruined
}

enum Ingredient
{
    Stardust = 1,
    SnakeVenom,
    DogBreath,
    ShadowGlass,
    GreenGem
}