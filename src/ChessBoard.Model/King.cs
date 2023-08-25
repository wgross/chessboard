namespace ChessBoard.Model;

public record King(BoardPosition Position) : IChessPiece
{
    public static King White(BoardPosition position) => new King(position);
    public static King Black(BoardPosition position) => new King(position);

    public IEnumerable<BoardPosition> GetThreats(ChessBoard board)
    {
        yield return this.Position with
        {
            X = this.Position.X - 1,
            Y = this.Position.Y - 1
        };

        yield return this.Position with
        {
            Y = this.Position.Y - 1
        };

        yield return this.Position with
        {
            X = this.Position.X + 1,
            Y = this.Position.Y - 1
        };

        yield return this.Position with
        {
            X = this.Position.X - 1
        };
        yield return this.Position with
        {
            X = this.Position.X + 1
        };

        yield return this.Position with
        {
            X = this.Position.X - 1,
            Y = this.Position.Y + 1
        };

        yield return this.Position with
        {
            Y = this.Position.Y + 1
        };

        yield return this.Position with
        {
            X = this.Position.X + 1,
            Y = this.Position.Y + 1
        };
    }
}