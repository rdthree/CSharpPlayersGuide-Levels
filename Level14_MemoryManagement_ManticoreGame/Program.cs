// See https://aka.ms/new-console-template for more information

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

// starting parameters
var manticoreDist = new Random(DateTime.Now.Millisecond).Next(100); // location of enemy
const int manticoreStartingHealth = 15;
var manticoreHealth = manticoreStartingHealth;
const int cityStartingHealth = 10;
var cityHealth = cityStartingHealth;
// location and power of cannon shots
const int damageMin = 1;
const int damageMed = 3;
const int damageMax = 10;
var round = 0; // increments each game loop

// helper consts for console messages
const int padding = 40;

while (manticoreHealth > 0 || cityHealth > 0)
{
    // each round these parameters change
    round += 1;
    manticoreDist -= 1;

    // initial parameters based on minimums and round bonuses
    var damage = damageMin;
    if (round % 3 == 0 && round % 5 == 0) damage = damageMax;
    else if (round % 3 == 0 || round % 5 == 0) damage = damageMed;

    // stats should update each round
    GameStats(damage, round, cityHealth, manticoreHealth, padding);

    // input next cannon shot at end of stats
    Console.Write("Input Range: ");
    var cannonShot = MoUtils.InputToInt();

    // console messages built into hit function, clear previous input and stats
    Console.Clear();
    var hit = Hit(cannonShot, manticoreDist, damage, damageMin, damageMed, damageMax);

    // hit results and endgame conditions
    if (hit) manticoreHealth -= damage;
    else if (!hit) cityHealth -= 1;
    
    // endgame conditions
    if (EndGame(cityHealth, manticoreHealth)) break;
}

Console.ReadKey();

void GameStats(int damage, int currentRound, int playerHealth, int enemyHealth, int paddings)
{
    // for some reason i can't pass this as a const parameter...caca!
    const int whitespace = 20;

    Console.WriteLine(("").PadRight(paddings, '-'));
    Console.WriteLine($"Round:              {currentRound,whitespace}");
    Console.WriteLine($"Possible Damage:    {damage,whitespace}");
    Console.WriteLine($"Manticore Health:   {enemyHealth,whitespace}");
    Console.WriteLine($"City Health:        {playerHealth,whitespace}");
    //Console.WriteLine($"Manticore Location: {enemyLocation,whitespace}");
    Console.WriteLine(("").PadRight(paddings, '-'));
}

bool Hit(int shot, int badDist, int damage, int damagePowerMin, int damagePowerMed, int damagePowerMax)
{
    if (shot == badDist)
    {
        if (damage == damagePowerMax)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("WHAMMER");
        }
        else if (damage == damagePowerMed)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("BLAMMER");
        }
        else if (damage == damagePowerMin)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("HIT");
        }

        Console.ResetColor();
        return true;
    }
    else
    {
        if (shot > badDist)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"OVERSHOT by {shot - badDist}");
        }
        else if (shot < badDist)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"UNDERSHOT by {badDist - shot}");
        }

        Console.ResetColor();
        return false;
    }
}

bool EndGame(int playerHealth, int enemyHealth)
{
    if (enemyHealth <= 0)
    {
#pragma warning disable CA1416
        Console.Beep(500, 150);
#pragma warning restore CA1416
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"WIN");
        return true;
    }
    else if (playerHealth <= 0)
    {
#pragma warning disable CA1416
        Console.Beep(250, 150);
#pragma warning restore CA1416
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"LOSE");
        return true;
    }
    else return false;
}