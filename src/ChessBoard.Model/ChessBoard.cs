namespace ChessBoard.Model;

public class ChessBoard
{
    private readonly Dictionary<BoardPosition, SquareState> squares;

    public ChessBoard(Dictionary<BoardPosition, SquareState> squares)
    {
        this.squares = squares;
    }

    public required BoardSize Dimensions { get; init; }

    private static IEnumerable<KeyValuePair<BoardPosition, SquareState>> AllSquares(BoardSize size)
    {
        for (int x = 0; x < size.Width; x++)
            for (int y = 0; y < size.Height; y++)
                yield return new(new BoardPosition(x, y), SquareState.Empty());
    }

    public static ChessBoard Square(BoardSize boardSize) => new ChessBoard(new Dictionary<BoardPosition, SquareState>(AllSquares(boardSize)))
    {
        Dimensions = boardSize,
    };

    public static ChessBoard CommonSquare() => Square(new BoardSize(8, 8));

    public IEnumerable<BoardPosition> GetColumn(BoardPosition through)
        => Enumerable.Range(0, this.Dimensions.Height).Select(row => through with { Y = row });

    public IEnumerable<BoardPosition> GetRow(BoardPosition through)
        => Enumerable.Range(0, this.Dimensions.Width).Select(column => through with { X = column });

    public IEnumerable<BoardPosition> GetDiagonalLeft(BoardPosition through)
    {
        int distanceLeft = Math.Min(through.X, through.Y);

        var lowerLeft = through with
        {
            X = through.X - distanceLeft,
            Y = through.Y - distanceLeft,
        };

        int distanceRight = Math.Min(this.Dimensions.Width - through.X, this.Dimensions.Height - through.Y - 1);

        var upperRight = through with
        {
            X = through.X + distanceRight,
            Y = through.Y + distanceRight,
        };

        return Enumerable
            .Range(0, upperRight.X - lowerLeft.X + 1)
            .Select(offset => lowerLeft with
            {
                X = lowerLeft.X + offset,
                Y = lowerLeft.Y + offset,
            });
    }

    public IEnumerable<BoardPosition> GetDiagonalRight(BoardPosition through)
    {
        int distanceLeft = Math.Min(through.X, this.Dimensions.Height - through.Y - 1);

        var upperLeft = through with
        {
            X = through.X - distanceLeft,
            Y = through.Y + distanceLeft,
        };

        int distanceRight = Math.Min(this.Dimensions.Width - through.X - 1, through.Y);

        var lowerRight = through with
        {
            X = through.X + distanceRight,
            Y = through.Y - distanceRight,
        };

        return Enumerable
            .Range(0, lowerRight.X - upperLeft.X + 1)
            .Select(offset => upperLeft with
            {
                X = upperLeft.X + offset,
                Y = upperLeft.Y - offset,
            });
    }

    public bool HasSquare(BoardPosition position) => this.squares.TryGetValue(position, out var _);
}