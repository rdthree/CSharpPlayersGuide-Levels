// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization.Json;
using MonchoUtils;

// HUNTING THE MANTICORE
/*
 * randomly place Manticore between 0 and 100
 *      - bring the manticore 1 step closer to the city with each round
 *      - manticore can only get within 1 step from the city
 * Manticore Begins with Health:    10
 * City Begins with Health:         15
 * Run game loop until Manticore or City reach health 0
 * Before each round, display round number, city health, manticore health
 * Compute Cannon Damage
 *      - 10 pts if round number is a multiple of 3 and 5
 *      - 3 pts if round is a multiple of 3 or 5
 *      - 1 pt if neither of the above is true
 * get target range from user and output: overshoot, short, hit
 *      - reduce health if hit
 * each round manticore is alive, reduce city health by 1 and advance to next round
 * display outcome at endgame
 * use different colors for different types of messages
 */

// starting vars

var manticoreDist = new Random(DateTime.Now.Millisecond).Next(100);
var manticoreStartingHealth = 15;
var manticoreHealth = manticoreStartingHealth;
var cityStartingHealth = 10;
var cityHealth = cityStartingHealth;
int cannonShot;
int round = 0;
int damage = 0;
const int whitespace = 5;
const int padding = 26;

while (manticoreHealth > 0 || cityHealth > 0)
{
    round += 1;
    manticoreDist -= 1;

    if (round % 3 == 0 && round % 5 == 0) damage = 10;
    else if (round % 3 == 0 || round % 5 == 0) damage = 3;
    else damage = 1;

    GameStats();

    Console.Write("Input Range: ");
    cannonShot = MoUtils.InputToInt();

    if (cannonShot > manticoreDist)
    {
        Console.WriteLine($"you overshot by {cannonShot - manticoreDist}");
        cityHealth -= 1;
    }
    else if (cannonShot < manticoreDist)
    {
        Console.WriteLine($"you undershot by {manticoreDist - cannonShot}");
        cityHealth -= 1;
    }
    else
    {
        if (damage == 10)
        {
            Console.WriteLine($"WHAMMER! {manticoreHealth -= 10}");
            continue;
        }
        else if (damage == 3)
        {
            Console.WriteLine($"BLAMMER! {manticoreHealth -= 3}");
            continue;
        }
        else
        {
            Console.WriteLine($"HIT! {manticoreHealth -= 1}");
            continue;
        }
    }
}

void GameStats()
{
    Console.WriteLine(("").PadRight(padding, '-'));
    Console.WriteLine($"Round:              {round,whitespace}");
    Console.WriteLine($"Possible Damage:    {damage,whitespace}");
    Console.WriteLine($"Manticore Health:   {manticoreHealth,whitespace}");
    Console.WriteLine($"City Health:        {cityHealth,whitespace}");
    Console.WriteLine($"Manticore Location: {manticoreDist,whitespace}");
    Console.WriteLine(("").PadRight(padding, '-'));
}

bool Hit(int shot, int badDist)
{
    return true;
}