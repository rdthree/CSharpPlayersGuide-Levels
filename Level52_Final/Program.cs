// dodge ball game - multi team

// update so player goes up against several teams. each team has its own captain, color, difficulty

using Level52_Final;
using Action = Level52_Final.Action;

var game = new Game();
game.GameRun();

internal class Game
{
    private Team Red { get; set; } = null!;
    private Character RedCaptain { get; set; } = null!;
    private readonly Random _random = new Random();

    private readonly List<CharacterNames> _namesList;

    private readonly List<Team> _otherTeams;


    internal Game()
    {
        _namesList = Character.CharacterNameList();
        Console.Write("player name: ");
        var redName = Console.ReadLine();

        PlayerTeamSetUp(redName, 5);
        _otherTeams = OtherTeamsSetup();
        var currentTeam = _otherTeams[0];

        // red or blue team start first random
        _ = _random.Next(10) >= 5 ? Red.CurrentTurn = true : currentTeam.CurrentTurn = true;
    }

    private void PlayerTeamSetUp(string? redName, int healthBoosts)
    {
        Red = new Team(TeamColor.Red, 3, healthBoosts);
        if (redName != null) RedCaptain = new Character(Red, redName, 10, true);
        Red.TeamList.Add(RedCaptain);
        for (var i = 0; i < Red.Size; i++)
            Red.TeamList.Add(new Character(Red, Character.NamePicker(_namesList), _random.Next(10)));
    }

    private List<Team> OtherTeamsSetup()
    {
        var otherTeams = new List<Team>();
        var teamDifficulty = 1;
        foreach (TeamColor teamColor in Enum.GetValues(typeof(TeamColor)))
        {
            if (teamColor == TeamColor.Red) continue;

            var team = new Team(teamColor, teamDifficulty);
            var captain = new Character(team, Character.NamePicker(_namesList), 10 + teamDifficulty, true);
            team.TeamList.Add(captain);

            for (var i = 0; i < team.Size; i++)
                team.TeamList.Add(new Character(team, Character.NamePicker(_namesList),
                    _random.Next(1, 5 + teamDifficulty)));

            otherTeams.Add(team);
            teamDifficulty++;
        }

        return otherTeams;
    }

    private static void HealthBooster(Team team)
    {
        foreach (var character in team.TeamList.Where(character =>
                     team.HealthBoosts > 0 && character.HP <= 3 && character._healthBoosts >= 1))
        {
            character.HP += 3;
            team.HealthBoosts--;
            Console.WriteLine($"{team.Color} {character.Name} health boosted: " +
                              $"{character.HP}/{character.OriginalHp}");
            Console.WriteLine($"{team.Color} Team has: {team.HealthBoosts} boosts left");
        }
    }

    private void WinLoseConditions(Team player, List<Team> opponentList, out bool winLose)
    {
        var opponent = opponentList[0];
        if (player.TeamList.Count < 1)
        {
            Console.WriteLine("Red Team Loses");
            winLose = false;
        }

        if (opponent.TeamList.Count < 1)
        {
            if (opponentList.Count <= 1)
            {
                Console.WriteLine("Red Team Wins");
                winLose = false;
            }

            Console.WriteLine($"{opponent.Color} Team loses");
            opponentList.Remove(opponent);
            opponent = opponentList[0];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Next Opponents: {opponent.Color} Team");
            foreach (var character in opponent.TeamList) Console.WriteLine($"{character.Name}");
            Console.ResetColor();

            // reset who's turn it is
            player.CurrentTurn = true;
        }

        winLose = true;
    }

    internal void GameRun()
    {
        var winLose = true;
        while (winLose)
        {
            var currentTeam = _otherTeams.First();

            if (Red.CurrentTurn) PlayTurn(Red);
            else if (currentTeam.CurrentTurn) PlayTurn(currentTeam);

            HealthBooster(Red);
            HealthBooster(currentTeam);
            WinLoseConditions(Red, _otherTeams, out winLose);
            currentTeam = _otherTeams[0]; // just in case the next team comes up

            Console.WriteLine($"{Red.Color}/{Red.Size} vs {currentTeam.Color}/{currentTeam.Size}");
            Console.WriteLine($"Other Teams Left: {_otherTeams.Count}");

            Thread.Sleep(3000);
        }
    }

    private void PlayTurn(Team team)
    {
        var character = team.TeamList[_random.Next(team.TeamList.Count)];

        PickAction(character);
        var otherCharacter = ShowCurrentTeamColor(character);


        if (otherCharacter.IsCaptain)
            Console.WriteLine($"UH OH ITS THE {character.Team.Color} " +
                              $"CAPTAIN {character.Name}");

        Console.WriteLine($"It is {character.Team.Color} Team {character.Name}'s turn.\n" +
                          $"{character.Team.Color} Team {character.Name} did a " +
                          $"{character.Action} on {otherCharacter.Name}\n");

        var hitPoints = HitPoints(character);
        otherCharacter.HP -= hitPoints;
        if (otherCharacter.HP < 1) otherCharacter.IsInGame = false;
        TeamStats();

        if (character.IsInGame)
        {
            Console.WriteLine(
                $"{character.Team.Color} {character.Name} scores {hitPoints}, " +
                $"{otherCharacter.Team.Color} {otherCharacter.Name} is at: {otherCharacter.HP}");

            Console.WriteLine($"{character.Team.Color} {character.Name} is at: " +
                              $"{character.HP}/{character.OriginalHp}");
        }

        TeamTurn();
        Console.ResetColor();
    }

    private Character ShowCurrentTeamColor(Character character)
    {
        var currentTeam = _otherTeams[0];
        Character otherCharacter;
        if (character.Team.Color == TeamColor.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            otherCharacter = currentTeam.TeamList[_random.Next(currentTeam.TeamList.Count)];
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
        var currentTeam = _otherTeams[0];
        if (currentTeam.CurrentTurn)
        {
            currentTeam.CurrentTurn = false;
            Red.CurrentTurn = true;
        }
        else if (Red.CurrentTurn)
        {
            Red.CurrentTurn = false;
            currentTeam.CurrentTurn = true;
        }
    }

    private void TeamStats()
    {
        var currentTeam = _otherTeams[0];
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var player in Red.TeamList.ToList().Where(player => !player.IsInGame))
        {
            Red.TeamList.Remove(player);
            Console.WriteLine($"{player.Name} from {TeamColor.Red} is out of the game.");
        }

        foreach (var player in currentTeam.TeamList.ToList().Where(player => !player.IsInGame))
        {
            currentTeam.TeamList.Remove(player);
            Console.WriteLine($"{player.Name} from {currentTeam.Color} is out of the game.");
        }

        Console.WriteLine($"{TeamColor.Red} Team has {Red.TeamList.Count} players");
        Console.WriteLine($"{currentTeam.Color} Team has {currentTeam.TeamList.Count} players");
        Console.ResetColor();
    }

    private void PickAction(Character character)
    {
        int choice;
        if (character.Team.Color is TeamColor.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Red Captain {RedCaptain.Name}, pick action (1-9, k): ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Remaining Teams");
                foreach (var otherTeam in _otherTeams)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{otherTeam.Color} : {otherTeam.TeamList.Count}");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var character1 in otherTeam.TeamList)
                        Console.WriteLine($"{character1.Name}:{character1.HP}/{character1.OriginalHp}");
                    Console.ResetColor();
                }

                Console.ResetColor();

                Console.Write($"Red Captain {RedCaptain.Name}, pick action (1-9): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

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