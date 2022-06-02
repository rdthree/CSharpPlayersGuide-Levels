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
        _otherTeams = OpponentTeamsSetup();
        var currentTeam = _otherTeams[0];

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

    private List<Team> OpponentTeamsSetup()
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
            Messages.HealthBoostMessage(team, character);
        }
    }

    private bool WinLoseConditions(Team player, List<Team> opponentList)
    {
        var opponent = opponentList.First();
        if (player.TeamList.Count < 1)
        {
            Messages.PlayerLose(player);
            return false;
        }

        if (opponent.TeamList.Count >= 1) return true;
        if (opponentList.Count <= 1)
        {
            Messages.PlayerWin(player);
            return false;
        }

        opponentList.Remove(opponent);
        opponent = opponentList.First();
        Messages.OpponentTeamLoses(opponent, opponentList);
        player.CurrentTurn = true; // reset so player starts next round

        return true;
    }

    internal void GameRun()
    {
        var winLose = true;
        while (winLose)
        {
            var currentTeam = _otherTeams.First();

            PlayTurn(Red.CurrentTurn ? Red : currentTeam);

            HealthBooster(Red);
            HealthBooster(currentTeam);

            winLose = WinLoseConditions(Red, _otherTeams);
            currentTeam = _otherTeams.First(); // just in case the next team comes up
            Messages.GameStatus(Red, currentTeam, _otherTeams);

            Thread.Sleep(3000);
        }
    }

    private void PlayTurn(Team team)
    {
        var character = team.TeamList[_random.Next(team.TeamList.Count)];
        var otherCharacter = RandomOpposingPlayer(character, Red, _otherTeams);
        
        PickAction(character);

        if (otherCharacter.IsCaptain) Messages.PlayOpponentCaptain(otherCharacter);
        Messages.TakeTurnsActionStats(character, otherCharacter);
        
        var hitPoints = HitPoints(character);
        otherCharacter.HP -= hitPoints;
        if (otherCharacter.HP < 1) otherCharacter.IsInGame = false;
        
        Messages.TakeTurnsTeamStats(Red, _otherTeams);
        if (character.IsInGame) Messages.TakeTurnsPlayerStats(character, otherCharacter, hitPoints);
        TeamTurn();
    }

    private Character RandomOpposingPlayer(Character character, Team playerTeam, List<Team> opposingTeamList)
    {
        var opponentTeam = opposingTeamList.First();
        var randomOpponent = character.Team.Color == playerTeam.Color
            ? opponentTeam.TeamList[_random.Next(opponentTeam.TeamList.Count)]
            : Red.TeamList[_random.Next(Red.TeamList.Count)];
        return randomOpponent;
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

    private void PickAction(Character character)
    {
        int choice;
        if (character.Team.Color is TeamColor.Red)
        {
            Messages.PlayerPickAction(RedCaptain);
            if (!int.TryParse(Console.ReadLine(), out choice)) Messages.PlayerPickActionStats(_otherTeams);
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