using Level31_FountainOfObjects;

// TODO: update proportions of senses from fountain, using size of room map
// TODO: randomize locations of stuff
// TODO: track wins, limit number of moves, give better messages
// TODO: cheat code to turn map on and off

var game = new Game(10, 30);
game.Run();

internal class FountainRoom : IInnerRoom
{
    public int Rows { get; }
    public int Columns { get; }
    public SenseTypes[,] SenseCoords { get; }
    public void RoomSize()
    {
        throw new NotImplementedException();
    }
}
