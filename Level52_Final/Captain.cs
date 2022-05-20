namespace Level52_Final;

internal class Captain : Character
{
    protected internal Captain(Team team) : base(team)
    {
    }

    protected internal Captain(Team team, string? name) : base(team, name)
    {
    }

    protected internal Captain(Team team, string? name, int hp) : base(team, name, hp)
    {
    }
}