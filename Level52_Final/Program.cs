// dodge ball game - multi team

// update so player goes up against several teams. each team has its own captain, color, difficulty

using Level52_Final;
using Action = Level52_Final.Action;

var game = new Game();
game.GameRun();

internal class Game
{
    private Team Red { get; set; } = null!;
    private Team Blue { get; set; } = null!;
    private Captain RedCaptain { get; set; } = null!;
    private Captain BlueCaptain { get; set; } = null!;
    private readonly Random _random = new Random();
    

    internal Game()
    {
        Console.Write("player name: ");
        var redName = Console.ReadLine();

        TeamSetUp(redName);

        // red or blue team start first random
        _ = _random.Next(1) == 0 ? RedCaptain.CurrentTurn = true : BlueCaptain.CurrentTurn = true;
    }

    private void TeamSetUp(string? redName)
    {
        Red = new Team(TeamColor.Red, 3);
        Blue = new Team(TeamColor.Blue, 3);

        RedCaptain = new Captain(Red, redName, 75);
        BlueCaptain = new Captain(Blue, "Blue Bozo", 50);

        Red.TeamList.Add(RedCaptain);
        for (var i = 0; i < Red.Size; i++)
            Red.TeamList.Add(new Character(Red, "generic player", _random.Next(10)));

        Blue.TeamList.Add(BlueCaptain);
        for (var i = 0; i < Blue.Size; i++)
            Blue.TeamList.Add(new Character(Blue, "generic player", _random.Next(10)));
    }

    internal void GameRun()
    {
        while (true)
        {
            if (RedCaptain.CurrentTurn) PlayTurn(Red);
            else if (BlueCaptain.CurrentTurn) PlayTurn(Blue);

            if (Red.TeamList.Count < 1)
            {
                Console.WriteLine("Red Team Wins");
                break;
            }

            if (Blue.TeamList.Count < 1)
            {
                Console.WriteLine("Blue Team Wins");
                break;
            }

            Thread.Sleep(3000);
        }
    }

    private void PlayTurn(Team team)
    {
        var character = team.TeamList[_random.Next(team.TeamList.Count)];

        PickAction(character);
        Character otherCharacter = ShowCurrentTeamColor(character);


        if (otherCharacter is Captain) Console.WriteLine($"UH OH ITS THE CAPTAIN");
        Console.WriteLine($"It is {character.Team.Color} {character.GetType()}'s turn.\n" +
                          $"{character.Team.Color} {character.GetType()} did a " +
                          $"{character.Action} on {otherCharacter.Name}\n");

        var hitPoints = HitPoints(character);
        otherCharacter.HP -= hitPoints;
        if (otherCharacter.HP < 1) otherCharacter.IsInGame = false;
        TeamStats();

        if (character.IsInGame)
        {
            Console.WriteLine($"{character.Name} scores {hitPoints}, {otherCharacter.Name} is at: {otherCharacter.HP}");
            Console.WriteLine($"{character} is at: {character.HP}/{character.OriginalHp}");
        }

        TeamTurn();
        Console.ResetColor();
    }

    private Character ShowCurrentTeamColor(Character character)
    {
        Character otherCharacter;
        if (character.Team.Color == TeamColor.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            otherCharacter = Blue.TeamList[_random.Next(Blue.TeamList.Count)];
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            otherCharacter = Red.TeamList[_random.Next(Red.TeamList.Count)];
        }

        return otherCharacter;
    }

    private void TeamTurn()
    {
        if (BlueCaptain.CurrentTurn)
        {
            BlueCaptain.CurrentTurn = false;
            RedCaptain.CurrentTurn = true;
        }
        else if (RedCaptain.CurrentTurn)
        {
            RedCaptain.CurrentTurn = false;
            BlueCaptain.CurrentTurn = true;
        }
    }

    private void TeamStats()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var player in Red.TeamList.ToList().Where(player => !player.IsInGame))
        {
            Red.TeamList.Remove(player);
            Console.WriteLine($"{player.Name} from {TeamColor.Red} is out of the game.");
        }

        foreach (var player in Blue.TeamList.ToList().Where(player => !player.IsInGame))
        {
            Blue.TeamList.Remove(player);
            Console.WriteLine($"{player.Name} from {TeamColor.Blue} is out of the game.");
        }

        Console.WriteLine($"{TeamColor.Red} has {Red.TeamList.Count} players");
        Console.WriteLine($"{TeamColor.Blue} has {Blue.TeamList.Count} players");
        Console.ResetColor();
    }

    private void PickAction(Character character)
    {
        int choice;
        if (character.Team.Color is TeamColor.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{RedCaptain.Name}, pick action (1-9): ");
            int.TryParse(Console.ReadLine(), out choice);
            Console.ResetColor();
        }
        else choice = _random.Next(1, 9);

        character.Action = choice switch
        {
            1 => Action.DoNothing,
            2 => Action.FastThrow,
            3 => Action.CurveThrow,
            4 => Action.FakeThrow,
            5 => Action.HardThrow,
            6 => Action.FastToss,
            7 => Action.ScrewToss,
            8 => Action.UnderToss,
            9 => Action.BounceToss,
            _ => Action.DoNothing
        };
    }

    private int HitPoints(Character character)
    {
        var hitPoints = character.Action switch
        {
            Action.DoNothing => 0,
            Action.FastThrow => _random.Next(0, 10),
            Action.CurveThrow => _random.Next(0, 9),
            Action.FakeThrow => _random.Next(0, 8),
            Action.BounceToss => 100,
            _ => _random.Next(0, 4),
        };

        return hitPoints;
    }
}