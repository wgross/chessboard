namespace ChessBoard.Model;

public record Rook(BoardPosition Position) : IChessPiece
{
    public static Rook White(BoardPosition position) => new Rook(position);

    public static Rook Black(BoardPosition position) => new Rook(position);

    public IEnumerable<BoardPosition> GetThreats(ChessBoard board)
        => board.GetColumn(through: this.Position).Concat(board.GetRow(through: this.Position)).Where(p => p != this.Position);
}