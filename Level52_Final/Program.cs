using Level52_Final;

var game = new Game();
game.GameRun();

internal class Game
{
    private Team Red { get; set; }
    private readonly List<Team> _otherTeams;

    internal Game()
    {
        var namesList = Character.CharacterNameList();
        Console.Write("player name: ");
        var redName = Console.ReadLine();

        Red = TeamSetup.Player(Red, namesList, redName, 5);
        _otherTeams = TeamSetup.Opponents(namesList);
        var currentTeam = _otherTeams[0];

        _ = Random.Shared.Next(10) >= 5 ? Red.CurrentTurn = true : currentTeam.CurrentTurn = true;
    }

    internal void GameRun()
    {
        var winLose = true;
        while (winLose)
        {
            var currentTeam = _otherTeams.First();

            Turn.Play(Red.CurrentTurn ? Red : currentTeam, Red, _otherTeams);
            HealthBooster(Red);
            HealthBooster(currentTeam);

            winLose = WinLoseConditions(Red, _otherTeams);
            currentTeam = _otherTeams.First(); // just in case the next team comes up
            Messages.GameStatus(Red, currentTeam, _otherTeams);

            Thread.Sleep(3000);
        }
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

    private static bool WinLoseConditions(Team player, List<Team> opponentList)
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
}