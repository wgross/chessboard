namespace ChessBoard.Model;

public record Pawn(BoardPosition Position, int Step) : IChessPiece
{
    public static Pawn Black(BoardPosition position) => new Pawn(position, -1);

    public static Pawn White(BoardPosition position) => new Pawn(position, 1);

    public IEnumerable<BoardPosition> GetThreats(ChessBoard board)
    {
        // en passant is missing

        yield return this.Position with
        {
            X = this.Position.X + 1,
            Y = this.Position.Y + this.Step
        };

        yield return this.Position with
        {
            X = this.Position.X - 1,
            Y = this.Position.Y + this.Step
        };
    }
}