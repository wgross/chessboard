namespace ChessBoard.Model;

public record Knight(BoardPosition Position) : IChessPiece
{
    public static Knight White(BoardPosition position) => new Knight(position);
    public static Knight Black(BoardPosition position) => new Knight(position);

    public IEnumerable<BoardPosition> GetThreats(ChessBoard board) => this.GetPossibleDestinationSquares().Where(board.HasSquare);

    private IEnumerable<BoardPosition> GetPossibleDestinationSquares()
    {
        yield return this.Position with
        {
            X = this.Position.X - 1,
            Y = this.Position.Y - 2
        };
        yield return this.Position with
        {
            X = this.Position.X + 1,
            Y = this.Position.Y - 2
        };
        yield return this.Position with
        {
            X = this.Position.X - 2,
            Y = this.Position.Y - 1
        };
        yield return this.Position with
        {
            X = this.Position.X + 2,
            Y = this.Position.Y - 1
        };
        yield return this.Position with
        {
            X = this.Position.X - 2,
            Y = this.Position.Y + 1
        };
        yield return this.Position with
        {
            X = this.Position.X + 2,
            Y = this.Position.Y + 1
        };
        yield return this.Position with
        {
            X = this.Position.X - 1,
            Y = this.Position.Y + 2
        };
        yield return this.Position with
        {
            X = this.Position.X + 1,
            Y = this.Position.Y + 2
        };
    }
}