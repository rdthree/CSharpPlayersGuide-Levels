using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal abstract class SubRoom : Coordinate
{
    protected SubRoom(int row, int column, int rowOffset, int colOffset) : base(row, column)
    {
        Location = new Coordinate(row - rowOffset, column - colOffset);

        CenterCoordList = new List<Coordinate>();
        EdgeCoordList = new List<Coordinate>();
        FieldCoordList = new List<Coordinate>();
        OuterFieldCoordList = new List<Coordinate>();

        CenterColor = ConsoleColor.Black;
        EdgeColor = CenterColor;
        FieldColor = EdgeColor;
        OuterFieldColor = FieldColor;

        CenterSymbol = 'x';
        EdgeSymbol = CenterSymbol;
        FieldSymbol = EdgeSymbol;
        OuterFieldSymbol = EdgeSymbol;

        BoundaryCoords = new Coordinate(0, 0);
        IsOn = true;
        
        LocateSenses();
    }

    /// <summary>
    /// Generally, the Location refers the center coordinate of the SubRoom
    /// </summary>
    public Coordinate Location { get; protected set; }

    /// <summary>
    /// Coordinate Lists used to draw sprites and locate "senses"
    /// </summary>
    public List<Coordinate> CenterCoordList { get; }

    public List<Coordinate> EdgeCoordList { get; }
    public List<Coordinate> FieldCoordList { get; }
    public List<Coordinate> OuterFieldCoordList { get; }

    /// <summary>
    /// Property and Method to turn SubRooms on and off
    /// </summary>
    public bool IsOn { get; protected internal set; }

    public Coordinate BoundaryCoords { get; protected init; }

    /// <summary>
    /// ConsoleColors used for drawing sprites
    /// </summary>
    public ConsoleColor CenterColor { get; protected init; }
    public ConsoleColor EdgeColor { get; protected init; }
    public ConsoleColor FieldColor { get; protected init; }
    public ConsoleColor OuterFieldColor { get; protected init; }

    /// <summary>
    /// chars used for drawing sprites
    /// </summary>
    public char CenterSymbol { get; protected init; }

    public char EdgeSymbol { get; protected init; }
    public char FieldSymbol { get; protected init; }
    public char OuterFieldSymbol { get; protected init; }

    /// <summary>
    /// Convenience method to layout all the "sense locations" for each sub class.  Order matters here as items will
    /// overwrite each-other sequentially.Large fields of coordinates go first, followed by successively smaller fields.
    /// The child class should call this base method last `base.BuildSenseCoordinates(i,j)`
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    protected virtual void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, 0, 0, CenterCoordList);
    }

    /// <summary>
    /// Variation of BuildSenseCoordinates but for adjacent "senses", corners adjacencies don't count
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    private void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, EdgeCoordList);
    }

    /// <summary>
    /// Lay out the "sense locations" for a specific "sense" within a SubRoom. Using, the center of an item's location
    /// as a reference point, these are added to the matching "sense" List within the SubRoom.
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    /// <param name="rowDist">rows the "sense" will emanate outwards from SubRoom center</param>
    /// <param name="colDist">columns the "sense" will emanate outwards from the SubRoom center</param>
    /// <param name="senseCoordList">corresponding List within the subclass where "sense" locations are added</param>
    protected void SenseCoordinate(int i, int j, int rowDist, int colDist, List<Coordinate> senseCoordList)
    {
        //(row, column) = RelativeToCoordinate(i, j, Location);
        var relativeCoordinate = RelativeToCoordinate(i, j, Location);
        //if (row > rowDist || column > colDist) return;
        if (relativeCoordinate.Row > rowDist || relativeCoordinate.Column > colDist) return;
        SenseCoords[i, j] = SenseTypeSelector(senseCoordList);
        senseCoordList.Add(new Coordinate(i, j));
    }

    /// <summary>
    /// Variation of SenseCoordinate for "sense" locations adjacent to the SubRoom center. Not corner adjacencies.
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    /// <param name="senseCoordList">corresponding List within the subclass where "sense" locations are added</param>
    private void SenseCoordinateAdjacent(int i, int j, List<Coordinate> senseCoordList)
    {
        var (row, column) = (Location.Row, Location.Column);
        if ((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
            (i != row || j != column + 1) && (i != row || j != column - 1)) return;
        SenseCoords[i, j] = SenseTypeSelector(senseCoordList);
        senseCoordList.Add(new Coordinate(i, j));
    }

    /// <summary>
    /// Returns a i,j coordinate relative to the target coordinate.
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    /// <param name="targetItemCoordinate">target coordinate</param>
    /// <returns></returns>
    private static Coordinate RelativeToCoordinate(int i, int j, Coordinate targetItemCoordinate)
    {
        var checkI = Math.Abs(targetItemCoordinate.Row - i);
        var checkJ = Math.Abs(targetItemCoordinate.Column - j);
        return new Coordinate(checkI, checkJ);
    }

    /// <summary>
    /// Runs the i,j for loop through the MainRoom coordinates to locate all senses.
    /// </summary>
    private void LocateSenses()
    {
        for (var i = 0; i < Row; i++)
        for (var j = 0; j < Column; j++)
        {
            BuildSenseCoordinates(i, j);
            BuildAdjSenseCoordinates(i, j);
        }
    }

    protected virtual SenseTypes SenseTypeSelector(List<Coordinate> senseCoordList) => SenseTypes.Nothing;
}