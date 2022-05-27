namespace Level52_Final;

internal class Captain : Character
{
    // protected internal Captain(Team team) : base(team)
    // {
    //     IsCaptain = true;
    // }
    //
    // protected internal Captain(Team team, int hp) : base(team, hp)
    // {
    //     IsCaptain = true;
    // }

    protected internal Captain(Team team, string? name) : base(team, name)
    {
        IsCaptain = true;
    }

    protected internal Captain(Team team, string? name, int hp) : base(team, name, hp)
    {
        IsCaptain = true;
    }
}