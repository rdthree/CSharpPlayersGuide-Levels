namespace Level52_Final;

internal class Team
{
    internal List<Character> TeamList { get; set; } = new List<Character>();
    internal int Size { get; init; }
    internal readonly TeamColor Color;
    internal bool CurrentTurn = false;

    internal Team(TeamColor color = TeamColor.Blue, int size = 10)
    {
        Size = size;
        Color = color;
    }
}